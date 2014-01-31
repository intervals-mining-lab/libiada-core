namespace LibiadaMusic.BorodaDivider
{
    public enum ParamEqualFM // класс для выбора метода сравнения ф-мотивов (с секвентным переносом, либо без)
    {
        /// <summary>
        /// Сравнивать Ф-мотивы с учетом секвентного переноса (0)
        /// </summary>
         Sequent = 0,
        /// <summary>
        /// Сравнивать Ф-мотивы не учитывая секвентного переноса (1)
        /// </summary>
         NonSequent = 1
    }
}
