namespace DataCommandTest.Check_Validate
{
    public static class Check_Symbol
    {
        public static bool CheckNumber(char s) => 48 <= s && s <= 57;
        public static bool CheckLatinBig(char s) => 65 <= s && s <= 90;
        public static bool CheckLatinSmall(char s) => 97 <= s && s <= 122;
        public static bool CheckRussianBig(char s) => 1040 <= s && s <= 1071;
        public static bool CheckRussianSmail(char s) => 1072 <= s && s <= 1103;
    }
}
