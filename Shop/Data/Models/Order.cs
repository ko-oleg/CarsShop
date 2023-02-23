using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        
        [Display(Name = "Введите имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не менее 2 символов")]
        public string name { get; set; }
        
        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина фамилии не менее 2 символов")]
        public string surname { get; set; }
        
        [Display(Name = "Введите адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина адреса не менее 2 символов")]
        public string adress { get; set; }
        
        [Display(Name = "Введите сотовый номер")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина номера не менее 10 знаков")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Введите почту")]
        [StringLength(40)]
        [Required(ErrorMessage = "Длина почты не менее 5 знаков")]
        public string email { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}