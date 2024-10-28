namespace LMSWebService.Models
{
    public class Source
    {
        /// <summary>
        /// Идентификационный номер источника возникновения лида в LMS.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификационный номер родительского источника возникновения лида в LMS.
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Идентификационный номер синонима источника возникновения лида в LMS.
        /// </summary>
        public int RefSourceId { get; set; }

        /// <summary>
        /// Название источника обращения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код записи во внешней системе.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Код источника в системе GM.
        /// </summary>
        public string GmCode { get; set; }
    }
}
