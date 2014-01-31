namespace LibiadaMusic.OIP.BorodaDivider
{
    public static class ParamEqualFM // класс для выбора метода сравнения ф-мотивов (с секвентным переносом, либо без)
    {
        static public int Sequent // Сравнивать Ф-мотивы с учетом секвентного переноса (0)
        {
            get
            {
                return 0;
            }
        }
        static public int NonSequent // Сравнивать Ф-мотивы не учитывая секвентного переноса (1)
        {
            get
            {
                return 1;
            }
        }
    }
}
