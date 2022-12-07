using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using DotsApi.Data;
namespace DotsApi.Data.Models{
    public class Dot{
        public int DotId { get; set; }
        // Позиция точки по X
        public int Xpos { get; set; }
        // Позиция точки по Y
        public int Ypos { get; set; }
        // Радиус точки
        public double Radius { get; set; }
        // Цвет точки
        public string Color { get; set; } = String.Empty;
        // Навигационное свойство
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}