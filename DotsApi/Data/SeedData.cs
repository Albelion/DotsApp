using Microsoft.EntityFrameworkCore;
using DotsApi.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotsApi.Data{
    public static class SeedData{
        public static void EnsureSeed(IApplicationBuilder app){
            DotsAppDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<DotsAppDbContext>();
            // Если есть ожидающая миграция, то совершаем ее
            if(context.Database.GetPendingMigrations().Any()){
                context.Database.Migrate();
            }

            // проверка наличия данных в базе
            if(!context.Dots.Any()&&!context.Comments.Any()){

                // инициализация данных по умолчанию
                Comment com1 = new Comment(){Text="comment 1", BackgroundColor = "green"};
                Comment com2 = new Comment(){Text = "comment 2", BackgroundColor = "red"};
                Comment com3 = new Comment(){Text = "comment 3", BackgroundColor = "grey"};
                Comment com4 = new Comment(){Text = "comment 4", BackgroundColor = "white"};
                Comment com5 = new Comment(){Text = "comment 5", BackgroundColor = "red"};
                Comment com6 = new Comment(){Text = "comment 6 looooooooooooooooong comment", BackgroundColor = "blue"};
                Comment com7 = new Comment(){Text = "comment 7", BackgroundColor = "grey"};
                Comment com8 = new Comment(){Text = "comment 8", BackgroundColor = "grey"};
                context.Comments.AddRange(com1, com2, com3, com4, com5, com6, com7, com8);
                
                context.Dots.AddRange(
                    new Dot(){
                        Color = "grey",
                        Xpos = 700,
                        Ypos = 400,
                        Radius = 25.0, 
                        Comments = {com1, com2}},
                    new Dot(){
                        Color = "red", 
                        Xpos = 1200, Ypos = 400, 
                        Radius = 35.0, 
                        Comments = {com3, com4, com5, com6, com7, com8}}
                );
                context.SaveChanges();
            }

        }
    }
}