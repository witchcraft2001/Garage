using System;
using Garage.Helpers;
using SQLite;

namespace Garage.Models
{
    public class BaseDataObject : ObservableObject
    {
        public BaseDataObject()
        {
            Id = 0;
            CreatedAt = DateTimeOffset.Now;
        }

        /// <summary>
        /// Id for item
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Azure created at time stamp
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Azure UpdateAt timestamp for online/offline sync
        /// </summary>
        public DateTimeOffset ChangedAt { get; set; }

    }
}
