using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Data.Models
{
    public class Order
    {
        //указываем что данное поле не показывается на стрничке
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(50, MinimumLength = 3)]
        //Задаем что поле обязательно и какая ошибка выведется в случае передачи менее 3 символов и не более 50
        [Required(ErrorMessage = "Длинна имени не менее 3 символов и не более 50")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(50, MinimumLength = 3)]
        //Задаем что поле обязательно и какая ошибка выведется в случае передачи менее 3 символов и не более 50
        [Required(ErrorMessage = "Длинна фамилии не менее 3 символов и не более 50")]
        public string SurName { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(50, MinimumLength = 10)]
        //Задаем что поле обязательно и какая ошибка выведется в случае передачи менее 10 символов и не более 50
        [Required(ErrorMessage = "Длинна адреса не менее 10 символов и не более 50")]
        public string Address { get; set; }

        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, MinimumLength = 6)]
        //Задаем что поле обязательно и какая ошибка выведется в случае передачи менее 6 символов и не более 50
        [Required(ErrorMessage = "Длинна номера телефона не менее 6 символов и не более 50")]
        public string Phone { get; set; }

        [Display(Name = "Введите email адрес")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 6)]
        //Задаем что поле обязательно и какая ошибка выведется в случае передачи менее 6 символов и не более 50
        [Required(ErrorMessage = "Длинна email адреса не менее 6 символов и не более 50")]
        public string Email { get; set; }

        //указываем что данное поле не показывается на страничке
        [BindNever]
        //Указываем что данное поле не просто скрыто, а вообще не отображается в исходном коде
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        [BindNever]
        //товары, которые приобретают
        public List<OrderDetail>? OrderDetails { get; set; } = null!;
    }
}
