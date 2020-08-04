﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        [MinLength(3, ErrorMessage = "you need to enter a least 3 characters for an order name")]
        [DisplayName("Name for the Order")]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [DisplayName("Meal")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        public int FootId { get; set; }
        
        [Required]
        [Range(1, 10, ErrorMessage = "you can select up to 10 meals")]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
