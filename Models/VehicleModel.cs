namespace LMSWebService.Models
{
    /// <summary>
    /// Представляет информацию о модели автомобиля.
    /// </summary>
    public class VehicleModel
    {
        /// <summary>
        /// Идентификатор модели в LMS, для автомобиля, указанного в обращении клиента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор бренда в LMS, для автомобиля, указанного в обращении клиента.
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Название модели, указанной клиентом в обращении.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код трейд-ин модели.
        /// </summary>
        public string TradeinCode { get; set; }

        /// <summary>
        /// Признак того, что модель используется в данное время.
        /// </summary>
        public bool IsRecent { get; set; }

        /// <summary>
        /// Порядковый номер записи для вывода в списках.
        /// </summary>
        public int Ord { get; set; }

        /// <summary>
        /// Признак удаления записи.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Признак коммерческого транспорта.
        /// </summary>
        public bool IsCommercial { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int OriginId { get; set; }

        /// <summary>
        /// Не используется.
        /// </summary>
        public int ModelClassId { get; set; }
    }
}
