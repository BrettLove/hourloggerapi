using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HourLoggerApi.Models
{
    [Table("hourlog")]
    public class Day
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("hours")]
        public float Hours { get; set; }

        [Column("date")]
        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}