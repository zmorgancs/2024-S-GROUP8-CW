import os
import pandas as pd
import requests
import json
import matplotlib.pyplot as plt

# Retrieve the token from an environment variable for security
token = "token here"
if not token:
    raise ValueError("GitHub token not found. Set the GITHUB_TOKEN environment variable.")

# Token list now only includes the one token
token_list = [token]
reponame = "UNLV-CS472-672/2024-S-GROUP8-CW"
ct = 0
ignore_date = pd.to_datetime("2023-02-16T00:00:00Z", utc=True)
ignored_file_extensions = [".pdf", ".xml", ".html", ".css", ".log", ".txt", ".json", ".js"]


def get_response(url, token_list, ct):
    jsonData = None
    len_tokens = len(token_list)
    try:
        ct = ct % len_tokens
        headers = {"Authorization": f"Token {token_list[ct]}" if token_list[ct] else None}
        request = requests.get(url, headers=headers)
        if request.status_code == 200:
            jsonData = request.json()
        else:
            print(f"Error fetching data: {request.status_code} - {request.text}")
        ct += 1
    except Exception as e:
        ct += 1
        print(f"An error occurred: {e}")
    return jsonData, ct


def contributors(reponame, token_list, ct):
    contributor_names = []
    contributor_logins = []
    login_to_name = dict()

    api = f"https://api.github.com/repos/{reponame}/contributors"

    try:
        contributor_array, ct = get_response(api, token_list, ct)

        if contributor_array is not None:
            for contributor_obj in contributor_array:
                contributor_name = ""
                contributor_api = f"https://api.github.com/users/{contributor_obj['login']}"
                contributor_obj2, ct = get_response(contributor_api, token_list, ct)
                if contributor_obj2 is not None and contributor_obj2["name"] is not None:
                    contributor_name = contributor_obj2["name"].split(" ")[0]
                    login_to_name[contributor_obj["login"]] = contributor_name

    except Exception as e:
        print(e)
    return login_to_name, ct


login_to_name, ct = contributors(reponame, token_list, ct)


def pullrequest_details(reponame, login_to_name, token_list, ct):
    contributor_pr_count = dict()
    contributor_pr_review_count = dict()
    contributor_changedFiles_count = dict()
    contributor_changedLOC = dict()

    try:
        ipage = 1
        while True:
            spage = str(ipage)
            pr_api = f"https://api.github.com/repos/{reponame}/pulls?page={spage}&per_page=100&state=closed"
            pr_list, ct = get_response(pr_api, token_list, ct)

            if len(pr_list) == 0:
                break

            for pr_obj in pr_list:
                pr_number = pr_obj["number"]
                login = pr_obj["user"]["login"]
                contri_name = login_to_name.get(login, login)

                if pr_obj["merged_at"] is not None:
                    merged_at = pr_obj["merged_at"]
                    date1 = pd.to_datetime(merged_at, utc=True)
                    difference = (date1 - ignore_date).total_seconds() // 3600

                    if difference > 0:
                        contributor_pr_count[contri_name] = contributor_pr_count.get(contri_name, 0) + 1

                        pr_changedFiles_api = f"https://api.github.com/repos/{reponame}/pulls/{pr_number}/files"
                        pr_changedFiles_list, ct = get_response(pr_changedFiles_api, token_list, ct)

                        for file_obj1 in pr_changedFiles_list:
                            file = file_obj1["filename"]
                            if not any(file.endswith(x) for x in ignored_file_extensions):
                                contributor_changedFiles_count[contri_name] = contributor_changedFiles_count.get(contri_name, 0) + 1
                                contributor_changedLOC[contri_name] = contributor_changedLOC.get(contri_name, 0) + file_obj1["changes"]

                        pr_reviews_api = f"https://api.github.com/repos/{reponame}/pulls/{pr_number}/reviews?per_page=100"
                        pr_reviews_list, ct = get_response(pr_reviews_api, token_list, ct)

                        already_reviewed = set()
                        if len(pr_reviews_list) != 0:
                            for pr_review_obj in pr_reviews_list:
                                login = pr_review_obj["user"]["login"]
                                if login not in login_to_name.keys():
                                    continue
                                reviewer_name = login_to_name[login]
                                if reviewer_name is not contri_name and reviewer_name not in already_reviewed:
                                    already_reviewed.add(reviewer_name)
                                    contributor_pr_review_count[reviewer_name] = contributor_pr_review_count.get(reviewer_name, 0) + 1

            ipage += 1
    except Exception as e:
        print("Error receiving data")
        print(e)

    return (
        contributor_pr_count,
        contributor_pr_review_count,
        contributor_changedFiles_count,
        contributor_changedLOC,
        ct,
    )


(
    contributor_pr_count,
    contributor_pr_review_count,
    contributor_changedFiles_count,
    contributor_changedLOC,
    ct,
) = pullrequest_details(reponame, login_to_name, token_list, ct)


def issue_details(reponame, login_to_name, token_list, ct):
    contributor_issue_count = dict()
    contributor_comment_count = dict()

    try:
        ipage = 1
        while True:
            spage = str(ipage)
            issue_api = f"https://api.github.com/repos/{reponame}/issues?page={spage}&per_page=100&state=all"
            issue_array, ct = get_response(issue_api, token_list, ct)

            if len(issue_array) == 0:
                break

            for issue_obj in issue_array:
                date1 = pd.to_datetime(issue_obj["created_at"], utc=True)
                difference = (date1 - ignore_date).total_seconds() // 3600

                if "pull_request" not in issue_obj.keys() and difference > 0:
                    login = issue_obj["user"]["login"]
                    contri_name = login_to_name.get(login, login)
                    contributor_issue_count[contri_name] = contributor_issue_count.get(contri_name, 0) + 1

                    issue_comments_api = issue_obj["comments_url"]
                    issue_comment_array, ct = get_response(issue_comments_api, token_list, ct)
                    if len(issue_comment_array) != 0:
                        for issue_comment_obj in issue_comment_array:
                            commenter_login = issue_comment_obj["user"]["login"]
                            commentor_name = login_to_name[commenter_login]
                            contributor_comment_count[commentor_name] = contributor_comment_count.get(commentor_name, 0) + 1

            ipage += 1
    except Exception as e:
        print(e)
        print("Error receiving data")

    return contributor_issue_count, contributor_comment_count, ct


contributor_issue_count, contributor_comment_count, ct = issue_details(reponame, login_to_name, token_list, ct)

df_pr = pd.DataFrame(contributor_pr_count.items(), columns=["Login", "PRs"])
df_prReviews = pd.DataFrame(contributor_pr_review_count.items(), columns=["Login", "PR_Reviews"])
df_pr_ChangedFiles = pd.DataFrame(contributor_changedFiles_count.items(), columns=["Login", "Changed_Files"])
df_pr_ChangedLOC = pd.DataFrame(contributor_changedLOC.items(), columns=["Login", "Changed_LOC"])
df_issues = pd.DataFrame(contributor_issue_count.items(), columns=["Login", "Issues"])
df_issues_comments = pd.DataFrame(contributor_comment_count.items(), columns=["Login", "Issue_Comments"])

df_list = [
    df_pr,
    df_prReviews,
    df_issues,
    df_issues_comments,
    df_pr_ChangedFiles,
    df_pr_ChangedLOC,
]

# Merge dataframes individually and handle NaNs at each step
df_merged = df_pr.merge(df_prReviews, on="Login", how="outer")
df_merged = df_merged.merge(df_issues, on="Login", how="outer")
df_merged = df_merged.merge(df_issues_comments, on="Login", how="outer")
df_merged = df_merged.merge(df_pr_ChangedFiles, on="Login", how="outer")
df_merged = df_merged.merge(df_pr_ChangedLOC, on="Login", how="outer")

# Fill NaNs with 0
df_merged = df_merged.fillna(0)

# Sort by Changed_LOC in descending order and take top 13 contributors
df_merged = df_merged.sort_values("Changed_LOC", ascending=False).head(13)

# Plotting
fig, axs = plt.subplots(3, 1, figsize=(10, 15))

# Plot PRs, PR Reviews, Issues, and Issue Comments
df_merged.plot(x="Login", y=["PRs", "PR_Reviews", "Issues", "Issue_Comments"], kind="bar", ax=axs[0], rot=45)
axs[0].set_title("Contributions")
axs[0].set_ylabel("Count")

# Plot Changed Files
df_merged.plot(x="Login", y=["Changed_Files"], kind="bar", ax=axs[1], rot=45, color="orange")
axs[1].set_title("Changed Files")
axs[1].set_ylabel("Count")

# Plot Changed Lines of Code
df_merged.plot(x="Login", y=["Changed_LOC"], kind="bar", ax=axs[2], rot=45, color="green")
axs[2].set_title("Changed Lines of Code")
axs[2].set_ylabel("Count")

plt.tight_layout()
plt.show()

# Save the final merged dataframe to a CSV for inspection
df_merged.to_csv('merged_data.csv', index=False)

