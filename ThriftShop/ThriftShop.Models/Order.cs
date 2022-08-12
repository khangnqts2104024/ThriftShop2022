﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShop.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public UserInfo UserInfo { get; } 
        [Required]
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }

        public int CouponId { get; set; }
        [ForeignKey("CouponId")]
        [ValidateNever]
        public Coupon? Coupon { get;  } 

        //User
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public List<OrderDetail>? orderDetails { get; set; } = new List<OrderDetail>();

    }
}
