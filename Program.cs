using System;

public enum MaterialType
{
    Plastic, Metal, Glass
}

public enum WeightCategory
{
    Light, Medium, Heavy
}

public class Package
{
    public MaterialType Material { get; set; }
    public float Weight { get; set; }

    public Package(MaterialType material, float weight)
    {
        Material = material;
        Weight = weight;
    }
}

public class PackageClassifier
{
    public static string ClassifyPackage(Package package)
    {
        WeightCategory weightCategory = GetWeightCategory(package.Weight);

        if ((package.Material == MaterialType.Plastic || package.Material == MaterialType.Metal) && weightCategory == WeightCategory.Light)
        {
            return "Section A";
        }
        else if ((package.Material == MaterialType.Metal || package.Material == MaterialType.Glass) && weightCategory == WeightCategory.Medium)
        {
            return "Section B";
        }
        else if (package.Material == MaterialType.Plastic && package.Weight == 4f)
        {
            return "Section C";
        }
        else if (weightCategory == WeightCategory.Heavy)
        {
            return "Section D";
        }
        else
        {
            return "Invalid section";
        }
    }

    private static WeightCategory GetWeightCategory(float weight)
    {
        if (weight > 0 && weight < 2f)
        {
            return WeightCategory.Light;
        }
        else if (weight <= 5f)
        {
            return WeightCategory.Medium;
        }
        else
        {
            return WeightCategory.Heavy;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the material type of the package (1 for Plastic, 2 for Metal, 3 for Glass):");
        if (int.TryParse(Console.ReadLine(), out int materialInput) && materialInput >= 1 && materialInput <= 3)
        {
            MaterialType materialType = (MaterialType)(materialInput - 1);

            Console.WriteLine("Enter the weight of the package (in kg):");
            if (float.TryParse(Console.ReadLine(), out float weight) && weight > 0)
            {
                Package package = new Package(materialType, weight);
                string section = PackageClassifier.ClassifyPackage(package);

                Console.WriteLine($"This package is {materialType}, and weighs {weight}kg.");
                Console.WriteLine($"The package will go to {section}.");
            }
            else
            {
                Console.WriteLine("Invalid weight input.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a number between 1 and 3.");
        }
    }
}