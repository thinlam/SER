using System.Text;

namespace BuildingBlocks.CrossCutting.ExtensionMethods;

public static class NumberExtension {
    public static string ToRoman(int number) {
        var numerals = new[] {
                (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
                (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
                (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
            };
        var result = new StringBuilder();
        foreach (var (value, symbol) in numerals) {
            while (number >= value) {
                result.Append(symbol);
                number -= value;
            }
        }

        return result.ToString();
    }
}