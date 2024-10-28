namespace LMSWebService.Models
{
    /// <summary>
    /// Представляет информацию об этапе запроса.
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// Идентификатор этапа в LMS.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор связанного запроса.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Идентификатор типа этапа.
        /// </summary>
        public int StageTypeId { get; set; }

        /// <summary>
        /// Дата и время последнего обновления данных по этапу.
        /// </summary>
        public DateTime LastTimeAt { get; set; }

        /// <summary>
        /// Дата и время закрытия этапа.
        /// </summary>
        public DateTime? FinishedAt { get; set; } // Nullable, так как этап может быть открытым

        /// <summary>
        /// Идентификатор типа результата закрытия этапа.
        /// </summary>
        public int ResultId { get; set; }

        /// <summary>
        /// Признак закрытия этапа.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Код (статус) текущего состояния обращения.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Время, оставшееся на обработку текущего этапа.
        /// </summary>
        public TimeSpan TimeLeft { get; set; }
    }
}
