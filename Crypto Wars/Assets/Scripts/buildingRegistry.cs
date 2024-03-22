// // Represents a building capable of producing units.
// public class BuildingRegistry
// {
//     // The name of the building.
//     public string Name { get; private set; }

//     // Constructor to create a new building with a specified name.
//     public Building(string name)
//     {
//         Name = name;
//     }

//     // Produces a unit card based on the specified unit type.
//     public Card ProduceUnit(UnitType unitType)
//     {
//         // Determines the unit to produce based on the unit type.
//         switch (unitType)
//         {
//             case UnitType.Light:
//                 return new Card(UnitType.Light, "Light Unit", 100);
//             case UnitType.Medium:
//                 return new Card(UnitType.Medium, "Medium Unit", 200);
//             case UnitType.Heavy:
//                 return new Card(UnitType.Heavy, "Heavy Unit", 300);
//             default:
//                 // Throws an exception if the unit type is not recognized.
//                 throw new ArgumentOutOfRangeException(nameof(unitType), $"Not expected unit type value: {unitType}");
//         }
//     }
// }