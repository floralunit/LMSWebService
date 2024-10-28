namespace LMSWebService.Models
{
    /// <summary>
    /// Представляет информацию о типе обращения в LMS.
    /// </summary>
    public class RequestType
    {
        /// <summary>
        /// Идентификатор типа обращения в LMS.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код записи.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Код подразделения (отдела), которое должно обрабатывать обращения указанного типа.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Название типа запроса (контактной формы сайта).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак видимости для категории обращения «Покупка».
        /// </summary>
        public bool ShowBuy { get; set; }

        /// <summary>
        /// Признак видимости для категории обращения «Кредит».
        /// </summary>
        public bool ShowCredit { get; set; }

        /// <summary>
        /// Признак видимости для категории обращения «Трейд-ин».
        /// </summary>
        public bool ShowTradeIn { get; set; }

        /// <summary>
        /// Признак видимости для категории обращения «Сервис».
        /// </summary>
        public bool ShowService { get; set; }

        /// <summary>
        /// Статус записи.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Название типа запроса (контактной формы сайта).
        /// </summary>
        public string NameDuplicate { get; set; } // Переименовано, чтобы избежать дублирования имени

        /// <summary>
        /// Описание этапов запроса.
        /// </summary>
        public List<Stage> Stages { get; set; }
    }

}
