using CrossPay.ElasticSearch.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public abstract class BaseEntity : IBaseModel
    {
        [Key]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public abstract class BaseEntity<T> : IBaseModel<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }


    public interface IBaseModel<T> : IBaseModel
    {
        public T Id { get; set; }


    }

    public interface IBaseModel {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class BaseModel<T> : IBaseModel<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class BaseModel : IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }


}
