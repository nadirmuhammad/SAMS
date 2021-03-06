﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class ServiceEquipment
    {
        public int ServiceEquipmentId { get; set; }
        public long ClientId { get; set; }
        public Nullable<System.DateTime> BillIssueDate { get; set; }
        public Nullable<long> ServiceNumber { get; set; }
        public string ChargeTypeDescription { get; set; }
        public Nullable<int> ServiceEquipmentTypeId { get; set; }
        public Nullable<decimal> InclGst { get; set; }
        public long BatchId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ImportBatch ImportBatch { get; set; }
        public virtual ServiceEquipmentServiceType ServiceEquipmentServiceType { get; set; }
    }
}
