namespace DataCommandTest.Check_Validate
{
    public static class Check_Fields
    {
        public static bool CheckOnlyNumbers(string field, string? allows = null) => field.All(symb => 
        Check_Symbol.CheckNumber(symb) ||
        (allows is null ? false : allows.Contains(symb)));
       public static bool CheckOnlyLetters(string field, string? allows = null) => field.All(symb => 
        Check_Symbol.CheckRussianBig(symb) ||
        Check_Symbol.CheckRussianSmail(symb) ||
        Check_Symbol.CheckLatinBig(symb) ||
        Check_Symbol.CheckLatinSmall(symb) ||
       (allows is null ? false : allows.Contains(symb)));
    }
}
