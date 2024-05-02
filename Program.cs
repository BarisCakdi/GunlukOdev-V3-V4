namespace GunlukOdev_V3_V4
{
    internal class Program
    {
        class Kayit
        {
            public string Metin { get; set; }
            public DateTime KayitTarihi { get; set; }
            public DateTime TarihGuncelleme { get; set; }
            public Kayit(string metin)
            {
                Metin = metin;
                KayitTarihi = DateTime.Now;
                TarihGuncelleme = DateTime.Now;
            }
        }

        static List<Kayit> kayitlar = new List<Kayit>();
        static void KullaniciGiris()
        {
            string admin = "bariscakdi";
            string editor = "orhanekici";
            string adminsifre = "asd123";
            string editorsifre = "123asd";

            while (true)
            {
                Console.Write("Merhaba lütfen kullanıcı adını yazınız: ");
                string kullaniciAdi = Console.ReadLine();
                Console.Write("Lütfen şifrenizi giriniz: ");
                string sifre = Console.ReadLine();
                Console.Clear();
                if (kullaniciAdi == admin && sifre == adminsifre)
                {
                    Console.WriteLine("Hoş geldin " + admin);
                    break;
                }
                else if (kullaniciAdi == editor && sifre == editorsifre)
                {
                    Console.WriteLine("Hoş geldin " + editor);
                    break;
                }
                else
                {
                    Console.WriteLine("Kayıtlı kullanıcı bulunamadı!!!");
                    continue;
                }
            }
        }
        static void MenuyeDon()
        {
            Console.WriteLine("\nMenüye dönmek için bir tuşa basın");
            Console.ReadKey(true);
            MenuGoster();
        }
        static void KayitlariListele() //Silme ve düzenlme işleminden sonra bug oluyor. Kontrol et
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTüm Kayıtlar");
            Console.ResetColor();
            if (kayitlar.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Listelenecek Kayıt bulunamadı.");
                Console.ResetColor();
            }
            for (int i = 0; i < kayitlar.Count; i++)
            {
                Console.Clear();
                kayitlar[i].KayitTarihi.ToString("ddMMyyyy");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Güncelleme Tarihi: {kayitlar[i].TarihGuncelleme}");
                Console.WriteLine($"Tarih: {kayitlar[i].KayitTarihi}");
                Console.WriteLine("==========================================");
                Console.ResetColor();
                Console.WriteLine($"{i + 1} - {kayitlar[i].Metin}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("==========================================");
                Console.ResetColor();
                Console.WriteLine("(S)onraki Kayıt || (A)na Menü || (D)üzenle || (X)Sil ");
                string inputSecim = Console.ReadLine();
                inputSecim = inputSecim.ToLower();
                if (inputSecim == "a")
                {
                    MenuyeDon();
                    break;
                }
                else if (inputSecim == "d")
                {

                    KayitDüzenle(i);
                    TxtKaydet();
                    MenuyeDon();
                    break;
                }
                else if (inputSecim == "x")
                {
                    Kayitsil(i);
                    TxtKaydet();
                    MenuyeDon();
                    break;
                }
                else if (inputSecim != "s")
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış seçim!");
                    i--;
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine("Başka kayıt bulunamadı!");
            MenuyeDon();
        }
        static void KayitEkle()
        {
            Console.Clear();
            DateTime bugun = DateTime.Today;
            bool gunlukteKayitVarmi = kayitlar.Any(p => p.KayitTarihi.Date == bugun);
            if (gunlukteKayitVarmi)
            {
                Console.WriteLine("Bugün kayıt eklediniz. Tekrardan eklemek istiyormusunuz? (E)vet/(H)ayır");
                string tekrarKayıt = Console.ReadLine();
                tekrarKayıt = tekrarKayıt.ToLower();
                if (tekrarKayıt == "e")//Güncelleme tarihi hepsinde değişiyor onu araştır.
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Günlüğe kayıt edilecekler: ");
                    Console.ResetColor();
                    string inputKayit = Console.ReadLine();
                    kayitlar.Add(new Kayit(inputKayit));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Kayıt alındı.");
                    Console.ResetColor();
                    TxtKaydet();
                    MenuyeDon();
                }
                MenuyeDon();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Günlüğe kayıt edilecekler: ");
                Console.ResetColor();
                string inputKayit = Console.ReadLine();
                kayitlar.Add(new Kayit(inputKayit));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Kayıt alındı.");
                Console.ResetColor();
                TxtKaydet();
                MenuyeDon();
            }
        }
        static void TümKayitlariSil()
        {
            Console.Clear();
            Console.WriteLine("\n Tüm kayıtları silmek istediğine emin misin (E/H)");
            string inputDelete = Console.ReadLine();
            inputDelete = inputDelete.ToUpper();
            if (inputDelete == "E")
            {
                kayitlar.Clear();
                Console.Clear();
                Console.WriteLine("Tüm Kayıtlar Silindi");
                TxtKaydet();
                MenuyeDon();
            }
            else
            {
                Console.WriteLine("Ana menü için bir tuşa basınız.");
                MenuyeDon();
            }
        }
        static void KayitDüzenle(int i)
        {
            Console.Clear();
            Kayit duzenlenicekKayit = kayitlar[i];
            Console.WriteLine("KAYIT DÜZENLEME");
            Console.WriteLine("=======================");
            Console.Write("Yeni metin giriniz: ");
            string yeniMetin = Console.ReadLine();
            duzenlenicekKayit.Metin = yeniMetin;
            DateTime yenitarih = DateTime.Now;
            duzenlenicekKayit.KayitTarihi = yenitarih;
            MenuGoster();
        }
        static void Kayitsil(int i)
        {
            Console.Clear();
            Console.WriteLine("Kayıt silmek istediğinize eminmisiniz? (E)vet/(H)ayır");
            string kayitsil = Console.ReadLine();
            kayitsil = kayitsil.ToLower();

            if (kayitsil == "e")
            {
                Kayit silinecekKayit = kayitlar[i];
                kayitlar.RemoveRange(i, 1);
                Console.WriteLine("Kayıt Silinmiştir!");
                TxtKaydet();
                MenuGoster();
            }
            MenuGoster();
        }
        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("GunlukV3-4-5.txt");
            foreach (var kayit in kayitlar)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                writer.WriteLine(kayit.KayitTarihi);
                Console.ResetColor();
                writer.WriteLine(kayit.Metin);
            }
        }
        static void KayitlariYukle()
        {
            using StreamReader reader = new StreamReader("GunlukV3-4-5.txt");

            string satir;
            while ((satir = reader.ReadLine()) != null)
            {
                string guncelKayit = satir;
                string metin = reader.ReadLine();
                DateTime kayitTarihi;
                if (DateTime.TryParse(guncelKayit, out kayitTarihi))
                {
                    kayitlar.Add(new Kayit(metin) { KayitTarihi = kayitTarihi });
                }
            }
        }
        static void MenuGoster(bool ilkAcilisMi = false)
        {
            Console.Clear();
            if (ilkAcilisMi)
            {
                Console.WriteLine("HOŞ GELDİNİZ");
            }
            Console.WriteLine("Günlük Uygulaması");
            Console.WriteLine("=========================");
            Console.WriteLine("1 - Kayıtları Listele");
            Console.WriteLine("2 - Yeni Kayıt Ekle");
            Console.WriteLine("3 - Tüm Kayıtları Sil");
            Console.WriteLine("4 - Çıkış");
            Console.Write("\nSeçiminiz: ");
            char inputSecim = Console.ReadKey().KeyChar;
            switch (inputSecim)
            {
                case '1':
                    KayitlariListele();
                    break;
                case '2':
                    KayitEkle();
                    break;
                case '3':
                    TümKayitlariSil();
                    break;
                case '4':
                    break;
                default:
                    Console.WriteLine("\nYanlış Tuşlama");
                    MenuyeDon();
                    break;

            }
        }
        static void Main(string[] args)
        {
            KullaniciGiris();
            KayitlariYukle();
            MenuGoster(true);
        }
    }
}
