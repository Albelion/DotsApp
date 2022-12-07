using System;
using System.Collections.Generic;
using DotsApi.Data;

namespace DotsApi.Data.Models{
    public class Comment{
        public int CommentId { get; set; }
        // Цвет подложки комментария
        public string BackgroundColor { get; set; } = String.Empty;
        // Текст комментария
        public string Text { get; set; } = String.Empty;
        // Внешний ключ на точку
        public int DotId {get; set;}
        // Навигационное свойство
        public Dot? Dot { get; set; }
    }
}