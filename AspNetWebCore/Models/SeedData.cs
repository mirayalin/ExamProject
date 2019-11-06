using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Logins.Any())
            {
                context.Logins.AddRange(

                    new Login()
                    {
                        Email = "mirayalin@hotmail.com",
                        KulaniciAdi = "miray",
                        Password = "123456",
                    },
                     new Login()
                     {
                         Email = "mirayalin1@hotmail.com",
                         KulaniciAdi = "miray1",
                         Password = "123456",
                     },
                      new Login()
                      {
                          Email = "mirayalin2@hotmail.com",
                          KulaniciAdi = "miray2",
                          Password = "123456",
                      },
                       new Login()
                       {
                           Email = "mirayalin3@hotmail.com",
                           KulaniciAdi = "miray3",
                           Password = "123456",
                       },
                        new Login()
                        {
                            Email = "mirayalin4@hotmail.com",
                            KulaniciAdi = "miray4",
                            Password = "123456",
                        });
                context.SaveChanges();
            }
        }
    }
}
