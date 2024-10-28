namespace LMSWebService.Models
{
    /// <summary>
    /// Представляет информацию о бренде автомобиля.
    /// </summary>
    public class VehicleBrand
    {
        /// <summary>
        /// Идентификационный номер бренда в LMS.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Русское название бренда.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Английское название бренда.
        /// </summary>
        public string NameEng { get; set; }

        /// <summary>
        /// Маркетинговое название бренда.
        /// </summary>
        public string NameMarket { get; set; }

        /// <summary>
        /// Ссылка на логотип бренда.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Название базы данных импортера.
        /// </summary>
        public string ImporterDbName { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int EcmId { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int IsSupported { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int OriginId { get; set; }

        /// <summary>
        /// Имеется ли VIN производителя.
        /// </summary>
        public int IsVinManufacturer { get; set; }

        /// <summary>
        /// Модель автомобиля, связанная с брендом.
        /// </summary>
        public VehicleModel VehicleModel { get; set; }
    }
}
