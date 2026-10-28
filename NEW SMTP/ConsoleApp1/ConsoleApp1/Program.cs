using System.Net;
using System.Net.Mail;

namespace ConsoleApp1
{
    internal class Program
    {
        static string fromMail = "elcanshirinov001@gmail.com";
        static string appPassword = "zece kkxr qusk tfzi";

        static void Main(string[] args)
        {

            Console.WriteLine("Adinizi daxil edin: ");
            string name = Console.ReadLine();

            Console.WriteLine("Gamil daxil edin: ");
            string tomail = Console.ReadLine();

            Console.WriteLine("Şifrenizi daxil edinI: ");
            string password = Console.ReadLine();


            DateTime startTime = DateTime.Now;
            Random Rand = new Random();
            string randomnumber = Rand.Next(1, 1000).ToString();
            try
            {
               

                var mail = new MailMessage();
                mail.From = new MailAddress(fromMail, "Qeydiyat");
                mail.To.Add(tomail);
                mail.Body = $"Sizin qeydiyyat təsdiq kodunuz{randomnumber }";

                var smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true; 
                smtp.Credentials = new NetworkCredential(fromMail, appPassword);
                smtp.Send(mail);

            }
            catch (Exception ex) {
                Console.WriteLine("Xeta basveerdi Gamil gondermede");
            }

           



            int MaxCeht = 1;

            while(MaxCeht <= 3)
            {
                


                if ((DateTime.Now - startTime).TotalSeconds > 3)
                {
                    Console.WriteLine("Vaxtiniz biti");
                    break;
                }
                Console.Write($"Testiq kodu (cehit:{MaxCeht} ): ");
                string testiq = Console.ReadLine();

                if (testiq == randomnumber) {
                    Console.WriteLine($" Təbriklər {name} Qeydiyyat uğurla tamamlandı ");
                    break;
                }
                else
                {
                    Console.WriteLine($"Yanlış kod Qalan cəhd: {3 - MaxCeht}");
                    MaxCeht++;
                }
            }
            Console.WriteLine("Biti");

        }
    }
}
