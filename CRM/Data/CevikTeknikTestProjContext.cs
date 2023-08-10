using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRM.Model;

#nullable disable

namespace CRM.Data
{
    public partial class CevikTeknikTestProjContext : DbContext
    {
        public CevikTeknikTestProjContext()
        {
        }

        public CevikTeknikTestProjContext(DbContextOptions<CevikTeknikTestProjContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cevaplar> Cevaplars { get; set; }
        public virtual DbSet<Izinler> Izinlers { get; set; }
        public virtual DbSet<KonuTuru> KonuTurus { get; set; }
        public virtual DbSet<Konular> Konulars { get; set; }
        public virtual DbSet<Kullanıcılar> Kullanıcılars { get; set; }
        public virtual DbSet<Resimler> Resimlers { get; set; }
        public virtual DbSet<Roller> Rollers { get; set; }
        public virtual DbSet<Scari> Scaris { get; set; }
        public virtual DbSet<Scarii> Scariis { get; set; }
        public virtual DbSet<Sstok> Sstoks { get; set; }
        public virtual DbSet<Stimage> Stimages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8ISJN39;Initial Catalog=CRMDB;Persist Security Info=True;User ID=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cevaplar>(entity =>
            {
                entity.ToTable("Cevaplar");

                entity.Property(e => e.Gorusulen).HasMaxLength(50);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Gorusen)
                    .WithMany(p => p.Cevaplars)
                    .HasForeignKey(d => d.GorusenId)
                    .HasConstraintName("FK_Cevaplar_Kullanıcılar");

                entity.HasOne(d => d.Konu)
                    .WithMany(p => p.Cevaplars)
                    .HasForeignKey(d => d.KonuId)
                    .HasConstraintName("FK_Cevaplar_Konular");
            });

            modelBuilder.Entity<Izinler>(entity =>
            {
                entity.ToTable("Izinler");
            });

            modelBuilder.Entity<KonuTuru>(entity =>
            {
                entity.ToTable("KonuTuru");

                entity.Property(e => e.Ad).HasMaxLength(50);
            });

            modelBuilder.Entity<Konular>(entity =>
            {
                entity.HasKey(e => e.KonuId);

                entity.ToTable("Konular");

                entity.Property(e => e.KonuId).HasColumnName("KonuID");

                entity.Property(e => e.CariId).HasColumnName("CariID");

                entity.Property(e => e.KullanıcıId).HasColumnName("KullanıcıID");

                entity.Property(e => e.StokId).HasColumnName("StokID");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.Property(e => e.TurId).HasColumnName("TurID");

                entity.HasOne(d => d.Tur)
                    .WithMany(p => p.Konulars)
                    .HasForeignKey(d => d.TurId)
                    .HasConstraintName("FK_Konular_KonuTuru");
            });

            modelBuilder.Entity<Kullanıcılar>(entity =>
            {
                entity.ToTable("Kullanıcılar");

                entity.Property(e => e.AdSoyad).HasMaxLength(50);
            });

            modelBuilder.Entity<Resimler>(entity =>
            {
                entity.HasKey(e => e.StImageId);

                entity.ToTable("Resimler");

                entity.Property(e => e.Tipi).HasMaxLength(10);
            });

            modelBuilder.Entity<Roller>(entity =>
            {
                entity.ToTable("Roller");

                entity.Property(e => e.Ad).HasMaxLength(50);
            });

            modelBuilder.Entity<Scari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("scari");

                entity.Property(e => e.Alici).HasColumnName("ALICI");

                entity.Property(e => e.Altacente).HasColumnName("ALTACENTE");

                entity.Property(e => e.Anabayi).HasColumnName("ANABAYI");

                entity.Property(e => e.Anlasmadate)
                    .HasColumnType("date")
                    .HasColumnName("ANLASMADATE");

                entity.Property(e => e.Avukat).HasColumnName("AVUKAT");

                entity.Property(e => e.Avukatdate)
                    .HasColumnType("date")
                    .HasColumnName("AVUKATDATE");

                entity.Property(e => e.Ayr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AYR");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Birthdateesi)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATEESI");

                entity.Property(e => e.Boy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOY");

                entity.Property(e => e.Carilimit).HasColumnName("CARILIMIT");

                entity.Property(e => e.CrAlacak).HasColumnName("CR_ALACAK");

                entity.Property(e => e.CrBorc).HasColumnName("CR_BORC");

                entity.Property(e => e.Crad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRAD");

                entity.Property(e => e.Cradres)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CRADRES");

                entity.Property(e => e.Crbirthdate)
                    .HasColumnType("date")
                    .HasColumnName("CRBIRTHDATE");

                entity.Property(e => e.Crcityid).HasColumnName("CRCITYID");

                entity.Property(e => e.Crcountryid).HasColumnName("CRCOUNTRYID");

                entity.Property(e => e.Cremail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREMAIL");

                entity.Property(e => e.Crfaiz).HasColumnName("CRFAIZ");

                entity.Property(e => e.Crfax)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CRFAX");

                entity.Property(e => e.Crgsm)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("CRGSM");

                entity.Property(e => e.CrgsmCopy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRGSM_COPY");

                entity.Property(e => e.Crid).HasColumnName("CRID");

                entity.Property(e => e.Crilce)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CRILCE");

                entity.Property(e => e.Crisim)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("CRISIM");

                entity.Property(e => e.Criskont).HasColumnName("CRISKONT");

                entity.Property(e => e.Cristhb)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRISTHB");

                entity.Property(e => e.Crkod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CRKOD");

                entity.Property(e => e.Crmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRMAIL");

                entity.Property(e => e.Crmuhkod)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CRMUHKOD");

                entity.Property(e => e.Crogretmen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CROGRETMEN");

                entity.Property(e => e.Crpostakod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRPOSTAKOD");

                entity.Property(e => e.Crrisklim).HasColumnName("CRRISKLIM");

                entity.Property(e => e.Crrota)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CRROTA");

                entity.Property(e => e.Crsehir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRSEHIR");

                entity.Property(e => e.Crsinif)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRSINIF");

                entity.Property(e => e.Crskype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRSKYPE");

                entity.Property(e => e.Crsoyad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRSOYAD");

                entity.Property(e => e.Crstateid).HasColumnName("CRSTATEID");

                entity.Property(e => e.Crtel)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL");

                entity.Property(e => e.Crtel2)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL2");

                entity.Property(e => e.Crtel2Copy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL2_COPY");

                entity.Property(e => e.Crtel3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL3");

                entity.Property(e => e.Crtel4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL4");

                entity.Property(e => e.CrtelCopy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRTEL_COPY");

                entity.Property(e => e.Crulke)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CRULKE");

                entity.Property(e => e.Crulkekod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CRULKEKOD");

                entity.Property(e => e.Crurl)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("CRURL");

                entity.Property(e => e.Crvade).HasColumnName("CRVADE");

                entity.Property(e => e.Crvergd)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CRVERGD");

                entity.Property(e => e.Crvergno)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("CRVERGNO");

                entity.Property(e => e.Crweb)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRWEB");

                entity.Property(e => e.Cryetkili)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRYETKILI");

                entity.Property(e => e.Degdate).HasColumnName("DEGDATE");

                entity.Property(e => e.Deguser).HasColumnName("DEGUSER");

                entity.Property(e => e.Demirbas).HasColumnName("DEMIRBAS");

                entity.Property(e => e.Efatura).HasColumnName("EFATURA");

                entity.Property(e => e.Esi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ESI");

                entity.Property(e => e.Esneklik)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ESNEKLIK");

                entity.Property(e => e.Expres).HasColumnName("EXPRES");

                entity.Property(e => e.Fasonislem).HasColumnName("FASONISLEM");

                entity.Property(e => e.Fatozelkod).HasColumnName("FATOZELKOD");

                entity.Property(e => e.Findik).HasColumnName("FINDIK");

                entity.Property(e => e.Fiyat).HasColumnName("FIYAT");

                entity.Property(e => e.FtDay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FT_DAY");

                entity.Property(e => e.Genelfire).HasColumnName("GENELFIRE");

                entity.Property(e => e.Gorusdate)
                    .HasColumnType("date")
                    .HasColumnName("GORUSDATE");

                entity.Property(e => e.Grup).HasColumnName("GRUP");

                entity.Property(e => e.Grupid).HasColumnName("GRUPID");

                entity.Property(e => e.Grupid2).HasColumnName("GRUPID2");

                entity.Property(e => e.Grupid4).HasColumnName("GRUPID4");

                entity.Property(e => e.Icra).HasColumnName("ICRA");

                entity.Property(e => e.Icradate)
                    .HasColumnType("date")
                    .HasColumnName("ICRADATE");

                entity.Property(e => e.Imafirkod)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("IMAFIRKOD");

                entity.Property(e => e.Isilislemdurum)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ISILISLEMDURUM");

                entity.Property(e => e.Iskonto).HasColumnName("ISKONTO");

                entity.Property(e => e.KAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("K_ADI");

                entity.Property(e => e.KIlgili)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("K_ILGILI");

                entity.Property(e => e.KKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("K_KODU");

                entity.Property(e => e.KNot)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("K_NOT");

                entity.Property(e => e.KTel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("K_TEL");

                entity.Property(e => e.Kalibiyapanfirma)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KALIBIYAPANFIRMA");

                entity.Property(e => e.Kalipgozad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KALIPGOZAD");

                entity.Property(e => e.Kayitdate).HasColumnName("KAYITDATE");

                entity.Property(e => e.Kilo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KILO");

                entity.Property(e => e.Kimlikno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KIMLIKNO");

                entity.Property(e => e.Kimliktip)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KIMLIKTIP");

                entity.Property(e => e.KisaNot1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT1");

                entity.Property(e => e.KisaNot2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT2");

                entity.Property(e => e.KisaNot3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT3");

                entity.Property(e => e.Kod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("KOD");

                entity.Property(e => e.Kuvvet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KUVVET");

                entity.Property(e => e.Mailgitti).HasColumnName("MAILGITTI");

                entity.Property(e => e.Malzeme).HasColumnName("MALZEME");

                entity.Property(e => e.Musfirkod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MUSFIRKOD");

                entity.Property(e => e.Musterinumune).HasColumnName("MUSTERINUMUNE");

                entity.Property(e => e.Notlar)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NOTLAR");

                entity.Property(e => e.Notlar2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOTLAR2");

                entity.Property(e => e.Notlar3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOTLAR3");

                entity.Property(e => e.Numuneonaydate)
                    .HasColumnType("date")
                    .HasColumnName("NUMUNEONAYDATE");

                entity.Property(e => e.Ogrdate)
                    .HasColumnType("date")
                    .HasColumnName("OGRDATE");

                entity.Property(e => e.Parcaag).HasColumnName("PARCAAG");

                entity.Property(e => e.Parcasektor)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARCASEKTOR");

                entity.Property(e => e.Pasif).HasColumnName("PASIF");

                entity.Property(e => e.Pasivasyon).HasColumnName("PASIVASYON");

                entity.Property(e => e.Personel).HasColumnName("PERSONEL");

                entity.Property(e => e.Pinbaccount).HasColumnName("PINBACCOUNT");

                entity.Property(e => e.Polkomisyon).HasColumnName("POLKOMISYON");

                entity.Property(e => e.Produktor).HasColumnName("PRODUKTOR");

                entity.Property(e => e.Salkimdokumag)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SALKIMDOKUMAG");

                entity.Property(e => e.Salkimparcaad).HasColumnName("SALKIMPARCAAD");

                entity.Property(e => e.Satici).HasColumnName("SATICI");

                entity.Property(e => e.Scarigrupaltid).HasColumnName("SCARIGRUPALTID");

                entity.Property(e => e.Sdergi)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SDERGI");

                entity.Property(e => e.Sdoto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SDOTO");

                entity.Property(e => e.Sertlik)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SERTLIK");

                entity.Property(e => e.Sex)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SEX");

                entity.Property(e => e.Sfirmaid).HasColumnName("SFIRMAID");

                entity.Property(e => e.Sgksicilno).HasColumnName("SGKSICILNO");

                entity.Property(e => e.Shobi)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SHOBI");

                entity.Property(e => e.Sicrama)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SICRAMA");

                entity.Property(e => e.Sigortasirket).HasColumnName("SIGORTASIRKET");

                entity.Property(e => e.Skaaks)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SKAAKS");

                entity.Property(e => e.Skarac)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SKARAC");

                entity.Property(e => e.Skarenk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKARENK");

                entity.Property(e => e.Skkm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SKKM");

                entity.Property(e => e.Sklup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SKLUP");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOYADI");

                entity.Property(e => e.Sozlesmebas).HasColumnName("SOZLESMEBAS");

                entity.Property(e => e.Sparaid).HasColumnName("SPARAID");

                entity.Property(e => e.Stokindirim).HasColumnName("STOKINDIRIM");

                entity.Property(e => e.Surat)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SURAT");

                entity.Property(e => e.Tamirhane).HasColumnName("TAMIRHANE");

                entity.Property(e => e.Teknikresim).HasColumnName("TEKNIKRESIM");

                entity.Property(e => e.Teknikresimno).HasColumnName("TEKNIKRESIMNO");

                entity.Property(e => e.Temfirkod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TEMFIRKOD");

                entity.Property(e => e.Teslimaciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TESLIMACIKLAMA");

                entity.Property(e => e.Ticimax).HasColumnName("TICIMAX");

                entity.Property(e => e.Tip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TIP");

                entity.Property(e => e.Toplamuretimad).HasColumnName("TOPLAMURETIMAD");

                entity.Property(e => e.Toplamuretimsayi).HasColumnName("TOPLAMURETIMSAYI");

                entity.Property(e => e.Topluft).HasColumnName("TOPLUFT");

                entity.Property(e => e.Unvkod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("UNVKOD");

                entity.Property(e => e.Uretimfire).HasColumnName("URETIMFIRE");

                entity.Property(e => e.Usercode).HasColumnName("USERCODE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.Property(e => e.Vekalet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VEKALET");

                entity.Property(e => e.Websifre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WEBSIFRE");

                entity.Property(e => e.Yetkilisatici).HasColumnName("YETKILISATICI");

                entity.Property(e => e.Yollukdurum).HasColumnName("YOLLUKDURUM");

                entity.Property(e => e.Yurtdisi).HasColumnName("YURTDISI");

                entity.Property(e => e.Yuzeykumlama).HasColumnName("YUZEYKUMLAMA");
            });

            modelBuilder.Entity<Scarii>(entity =>
            {
                entity.HasKey(e => e.Crid)
                    .HasName("PK_scari_CRID");

                entity.ToTable("scarii");

                entity.HasIndex(e => e.Crid, "scari$CRID")
                    .IsUnique();

                entity.HasIndex(e => e.Crisim, "scari$CRISIM")
                    .IsUnique();

                entity.HasIndex(e => e.Crkod, "scari$CRKOD")
                    .IsUnique();

                entity.Property(e => e.Crid).HasColumnName("CRID");

                entity.Property(e => e.Alici)
                    .HasColumnName("ALICI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Altacente).HasColumnName("ALTACENTE");

                entity.Property(e => e.Anabayi)
                    .HasColumnName("ANABAYI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Anlasmadate)
                    .HasColumnType("date")
                    .HasColumnName("ANLASMADATE");

                entity.Property(e => e.Avukat)
                    .HasColumnName("AVUKAT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Avukatdate)
                    .HasColumnType("date")
                    .HasColumnName("AVUKATDATE");

                entity.Property(e => e.Ayr)
                    .HasMaxLength(10)
                    .HasColumnName("AYR");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Birthdateesi)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATEESI");

                entity.Property(e => e.Boy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOY");

                entity.Property(e => e.Carilimit)
                    .HasColumnName("CARILIMIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrAlacak).HasColumnName("CR_ALACAK");

                entity.Property(e => e.CrBorc).HasColumnName("CR_BORC");

                entity.Property(e => e.Crad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRAD");

                entity.Property(e => e.Cradres)
                    .HasMaxLength(200)
                    .HasColumnName("CRADRES");

                entity.Property(e => e.Crbirthdate)
                    .HasColumnType("date")
                    .HasColumnName("CRBIRTHDATE");

                entity.Property(e => e.Crcityid)
                    .HasColumnName("CRCITYID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Crcountryid)
                    .HasColumnName("CRCOUNTRYID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cremail)
                    .HasMaxLength(100)
                    .HasColumnName("CREMAIL");

                entity.Property(e => e.Crfaiz).HasColumnName("CRFAIZ");

                entity.Property(e => e.Crfax)
                    .HasMaxLength(30)
                    .HasColumnName("CRFAX");

                entity.Property(e => e.Crgsm)
                    .HasMaxLength(38)
                    .HasColumnName("CRGSM");

                entity.Property(e => e.CrgsmCopy)
                    .HasMaxLength(50)
                    .HasColumnName("CRGSM_COPY");

                entity.Property(e => e.Crilce)
                    .HasMaxLength(40)
                    .HasColumnName("CRILCE");

                entity.Property(e => e.Crisim)
                    .HasMaxLength(120)
                    .HasColumnName("CRISIM");

                entity.Property(e => e.Criskont).HasColumnName("CRISKONT");

                entity.Property(e => e.Cristhb)
                    .HasMaxLength(100)
                    .HasColumnName("CRISTHB");

                entity.Property(e => e.Crkod)
                    .HasMaxLength(32)
                    .HasColumnName("CRKOD");

                entity.Property(e => e.Crmail)
                    .HasMaxLength(50)
                    .HasColumnName("CRMAIL");

                entity.Property(e => e.Crmuhkod)
                    .HasMaxLength(40)
                    .HasColumnName("CRMUHKOD");

                entity.Property(e => e.Crogretmen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CROGRETMEN");

                entity.Property(e => e.Crpostakod)
                    .HasMaxLength(10)
                    .HasColumnName("CRPOSTAKOD");

                entity.Property(e => e.Crrisklim).HasColumnName("CRRISKLIM");

                entity.Property(e => e.Crrota)
                    .HasMaxLength(80)
                    .HasColumnName("CRROTA");

                entity.Property(e => e.Crsehir)
                    .HasMaxLength(50)
                    .HasColumnName("CRSEHIR");

                entity.Property(e => e.Crsinif)
                    .HasMaxLength(10)
                    .HasColumnName("CRSINIF");

                entity.Property(e => e.Crskype)
                    .HasMaxLength(50)
                    .HasColumnName("CRSKYPE");

                entity.Property(e => e.Crsoyad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRSOYAD");

                entity.Property(e => e.Crstateid)
                    .HasColumnName("CRSTATEID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Crtel)
                    .HasMaxLength(38)
                    .HasColumnName("CRTEL");

                entity.Property(e => e.Crtel2)
                    .HasMaxLength(38)
                    .HasColumnName("CRTEL2");

                entity.Property(e => e.Crtel2Copy)
                    .HasMaxLength(50)
                    .HasColumnName("CRTEL2_COPY");

                entity.Property(e => e.Crtel3)
                    .HasMaxLength(50)
                    .HasColumnName("CRTEL3");

                entity.Property(e => e.Crtel4)
                    .HasMaxLength(50)
                    .HasColumnName("CRTEL4");

                entity.Property(e => e.CrtelCopy)
                    .HasMaxLength(50)
                    .HasColumnName("CRTEL_COPY");

                entity.Property(e => e.Crulke)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CRULKE");

                entity.Property(e => e.Crulkekod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CRULKEKOD");

                entity.Property(e => e.Crurl)
                    .HasMaxLength(120)
                    .HasColumnName("CRURL");

                entity.Property(e => e.Crvade).HasColumnName("CRVADE");

                entity.Property(e => e.Crvergd)
                    .HasMaxLength(40)
                    .HasColumnName("CRVERGD");

                entity.Property(e => e.Crvergno)
                    .HasMaxLength(28)
                    .HasColumnName("CRVERGNO");

                entity.Property(e => e.Crweb)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRWEB");

                entity.Property(e => e.Cryetkili)
                    .HasMaxLength(100)
                    .HasColumnName("CRYETKILI");

                entity.Property(e => e.Degdate)
                    .HasPrecision(0)
                    .HasColumnName("DEGDATE");

                entity.Property(e => e.Deguser).HasColumnName("DEGUSER");

                entity.Property(e => e.Demirbas)
                    .HasColumnName("DEMIRBAS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Efatura)
                    .HasColumnName("EFATURA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Esi)
                    .HasMaxLength(20)
                    .HasColumnName("ESI");

                entity.Property(e => e.Esneklik)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ESNEKLIK");

                entity.Property(e => e.Expres).HasColumnName("EXPRES");

                entity.Property(e => e.Fasonislem)
                    .HasColumnName("FASONISLEM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fatozelkod)
                    .HasColumnName("FATOZELKOD")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Findik)
                    .HasColumnName("FINDIK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fiyat).HasColumnName("FIYAT");

                entity.Property(e => e.FtDay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FT_DAY");

                entity.Property(e => e.Genelfire).HasColumnName("GENELFIRE");

                entity.Property(e => e.Gorusdate)
                    .HasColumnType("date")
                    .HasColumnName("GORUSDATE");

                entity.Property(e => e.Grup).HasColumnName("GRUP");

                entity.Property(e => e.Grupid).HasColumnName("GRUPID");

                entity.Property(e => e.Grupid2)
                    .HasColumnName("GRUPID2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Grupid4)
                    .HasColumnName("GRUPID4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Icra)
                    .HasColumnName("ICRA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Icradate)
                    .HasColumnType("date")
                    .HasColumnName("ICRADATE");

                entity.Property(e => e.Imafirkod)
                    .HasMaxLength(12)
                    .HasColumnName("IMAFIRKOD");

                entity.Property(e => e.Isilislemdurum)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ISILISLEMDURUM");

                entity.Property(e => e.Iskonto).HasColumnName("ISKONTO");

                entity.Property(e => e.KAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("K_ADI");

                entity.Property(e => e.KIlgili)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("K_ILGILI");

                entity.Property(e => e.KKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("K_KODU");

                entity.Property(e => e.KNot)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("K_NOT");

                entity.Property(e => e.KTel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("K_TEL");

                entity.Property(e => e.Kalibiyapanfirma)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KALIBIYAPANFIRMA");

                entity.Property(e => e.Kalipgozad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KALIPGOZAD");

                entity.Property(e => e.Kayitdate)
                    .HasPrecision(0)
                    .HasColumnName("KAYITDATE");

                entity.Property(e => e.Kilo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KILO");

                entity.Property(e => e.Kimlikno)
                    .HasMaxLength(20)
                    .HasColumnName("KIMLIKNO");

                entity.Property(e => e.Kimliktip)
                    .HasMaxLength(4)
                    .HasColumnName("KIMLIKTIP");

                entity.Property(e => e.KisaNot1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT1");

                entity.Property(e => e.KisaNot2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT2");

                entity.Property(e => e.KisaNot3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KISA_NOT3");

                entity.Property(e => e.Kod)
                    .HasMaxLength(30)
                    .HasColumnName("KOD");

                entity.Property(e => e.Kuvvet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KUVVET");

                entity.Property(e => e.Mailgitti)
                    .HasColumnName("MAILGITTI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Malzeme).HasColumnName("MALZEME");

                entity.Property(e => e.Musfirkod)
                    .HasMaxLength(30)
                    .HasColumnName("MUSFIRKOD");

                entity.Property(e => e.Musterinumune)
                    .HasColumnName("MUSTERINUMUNE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Notlar)
                    .HasMaxLength(150)
                    .HasColumnName("NOTLAR");

                entity.Property(e => e.Notlar2)
                    .HasMaxLength(250)
                    .HasColumnName("NOTLAR2");

                entity.Property(e => e.Notlar3)
                    .HasMaxLength(255)
                    .HasColumnName("NOTLAR3");

                entity.Property(e => e.Numuneonaydate)
                    .HasColumnType("date")
                    .HasColumnName("NUMUNEONAYDATE");

                entity.Property(e => e.Ogrdate)
                    .HasColumnType("date")
                    .HasColumnName("OGRDATE");

                entity.Property(e => e.Parcaag).HasColumnName("PARCAAG");

                entity.Property(e => e.Parcasektor)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARCASEKTOR");

                entity.Property(e => e.Pasif)
                    .HasColumnName("PASIF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pasivasyon)
                    .HasColumnName("PASIVASYON")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Personel)
                    .HasColumnName("PERSONEL")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pinbaccount)
                    .HasColumnName("PINBACCOUNT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Polkomisyon).HasColumnName("POLKOMISYON");

                entity.Property(e => e.Produktor).HasColumnName("PRODUKTOR");

                entity.Property(e => e.Salkimdokumag)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SALKIMDOKUMAG");

                entity.Property(e => e.Salkimparcaad).HasColumnName("SALKIMPARCAAD");

                entity.Property(e => e.Satici)
                    .HasColumnName("SATICI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Scarigrupaltid)
                    .HasColumnName("SCARIGRUPALTID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sdergi)
                    .HasMaxLength(255)
                    .HasColumnName("SDERGI");

                entity.Property(e => e.Sdoto)
                    .HasMaxLength(200)
                    .HasColumnName("SDOTO");

                entity.Property(e => e.Sertlik)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SERTLIK");

                entity.Property(e => e.Sex)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SEX");

                entity.Property(e => e.Sfirmaid)
                    .HasColumnName("SFIRMAID")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Sgksicilno).HasColumnName("SGKSICILNO");

                entity.Property(e => e.Shobi)
                    .HasMaxLength(255)
                    .HasColumnName("SHOBI");

                entity.Property(e => e.Sicrama)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SICRAMA");

                entity.Property(e => e.Sigortasirket).HasColumnName("SIGORTASIRKET");

                entity.Property(e => e.Skaaks)
                    .HasMaxLength(255)
                    .HasColumnName("SKAAKS");

                entity.Property(e => e.Skarac)
                    .HasMaxLength(255)
                    .HasColumnName("SKARAC");

                entity.Property(e => e.Skarenk)
                    .HasMaxLength(100)
                    .HasColumnName("SKARENK");

                entity.Property(e => e.Skkm)
                    .HasMaxLength(30)
                    .HasColumnName("SKKM");

                entity.Property(e => e.Sklup)
                    .HasMaxLength(255)
                    .HasColumnName("SKLUP");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(100)
                    .HasColumnName("SOYADI");

                entity.Property(e => e.Sozlesmebas)
                    .HasPrecision(0)
                    .HasColumnName("SOZLESMEBAS");

                entity.Property(e => e.Sparaid).HasColumnName("SPARAID");

                entity.Property(e => e.Stokindirim).HasColumnName("STOKINDIRIM");

                entity.Property(e => e.Surat)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SURAT");

                entity.Property(e => e.Tamirhane).HasColumnName("TAMIRHANE");

                entity.Property(e => e.Teklif)
                    .HasColumnName("TEKLIF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Teknikresim)
                    .HasColumnName("TEKNIKRESIM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Teknikresimno).HasColumnName("TEKNIKRESIMNO");

                entity.Property(e => e.Temfirkod)
                    .HasMaxLength(30)
                    .HasColumnName("TEMFIRKOD");

                entity.Property(e => e.Teslimaciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TESLIMACIKLAMA");

                entity.Property(e => e.Ticimax)
                    .HasColumnName("TICIMAX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("TIP")
                    .HasDefaultValueSql("(N'ÖZEL')");

                entity.Property(e => e.Toplamuretimad).HasColumnName("TOPLAMURETIMAD");

                entity.Property(e => e.Toplamuretimsayi).HasColumnName("TOPLAMURETIMSAYI");

                entity.Property(e => e.Topluft)
                    .HasColumnName("TOPLUFT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Unvkod)
                    .HasMaxLength(30)
                    .HasColumnName("UNVKOD");

                entity.Property(e => e.Uretimfire).HasColumnName("URETIMFIRE");

                entity.Property(e => e.Usercode).HasColumnName("USERCODE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.Property(e => e.Vekalet)
                    .HasMaxLength(50)
                    .HasColumnName("VEKALET");

                entity.Property(e => e.Websifre)
                    .HasMaxLength(30)
                    .HasColumnName("WEBSIFRE");

                entity.Property(e => e.Yetkilisatici)
                    .HasColumnName("YETKILISATICI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yollukdurum).HasColumnName("YOLLUKDURUM");

                entity.Property(e => e.Yurtdisi)
                    .HasColumnName("YURTDISI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yuzeykumlama).HasColumnName("YUZEYKUMLAMA");
            });

            modelBuilder.Entity<Sstok>(entity =>
            {
                entity.HasKey(e => e.Sstokid)
                    .IsClustered(false);

                entity.ToTable("sstok");

                entity.HasIndex(e => e.Sstokid, "sstok$SSTOKID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sstokid).HasColumnName("SSTOKID");

                entity.Property(e => e.Acilismiktari)
                    .HasColumnName("ACILISMIKTARI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Article)
                    .HasMaxLength(100)
                    .HasColumnName("ARTICLE");

                entity.Property(e => e.Backingid).HasColumnName("BACKINGID");

                entity.Property(e => e.Baglamakodu)
                    .HasMaxLength(20)
                    .HasColumnName("BAGLAMAKODU");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(30)
                    .HasColumnName("BARCODE");

                entity.Property(e => e.Barcode9)
                    .HasColumnName("BARCODE9")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Baskisuresi).HasColumnName("BASKISURESI");

                entity.Property(e => e.Beden)
                    .HasMaxLength(50)
                    .HasColumnName("BEDEN");

                entity.Property(e => e.Berabertasima)
                    .HasMaxLength(50)
                    .HasColumnName("BERABERTASIMA");

                entity.Property(e => e.Blocksizeid).HasColumnName("BLOCKSIZEID");

                entity.Property(e => e.Caritur)
                    .HasMaxLength(1)
                    .HasColumnName("CARITUR");

                entity.Property(e => e.Caritur2)
                    .HasMaxLength(2)
                    .HasColumnName("CARITUR2");

                entity.Property(e => e.Cikis).HasColumnName("CIKIS");

                entity.Property(e => e.Color1).HasColumnName("COLOR1");

                entity.Property(e => e.Color2).HasColumnName("COLOR2");

                entity.Property(e => e.Color3).HasColumnName("COLOR3");

                entity.Property(e => e.Cozelti)
                    .HasColumnName("COZELTI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Degdate)
                    .HasPrecision(0)
                    .HasColumnName("DEGDATE");

                entity.Property(e => e.Deguser)
                    .HasColumnName("DEGUSER")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Demirbas)
                    .HasColumnName("DEMIRBAS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Designind).HasColumnName("DESIGNIND");

                entity.Property(e => e.Disambalaj)
                    .HasColumnName("DISAMBALAJ")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dokumsicakligi)
                    .HasColumnName("DOKUMSICAKLIGI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ekambalaj)
                    .HasColumnName("EKAMBALAJ")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Enjfire).HasColumnName("ENJFIRE");

                entity.Property(e => e.Enustid)
                    .HasColumnName("ENUSTID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Eticaretgrup1).HasColumnName("ETICARETGRUP1");

                entity.Property(e => e.Eticaretgrup2).HasColumnName("ETICARETGRUP2");

                entity.Property(e => e.Eticaretgrup3).HasColumnName("ETICARETGRUP3");

                entity.Property(e => e.Eticaretgrup4).HasColumnName("ETICARETGRUP4");

                entity.Property(e => e.Eticaretkod)
                    .HasMaxLength(20)
                    .HasColumnName("ETICARETKOD");

                entity.Property(e => e.Fasonaciklama)
                    .HasMaxLength(250)
                    .HasColumnName("FASONACIKLAMA");

                entity.Property(e => e.Fasonislem)
                    .HasColumnName("FASONISLEM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Filtreid).HasColumnName("FILTREID");

                entity.Property(e => e.Firinsicakligi)
                    .HasColumnName("FIRINSICAKLIGI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gecerliliktrh)
                    .HasColumnType("date")
                    .HasColumnName("GECERLILIKTRH");

                entity.Property(e => e.Genelfire)
                    .HasColumnName("GENELFIRE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Genelmalzeme).HasColumnName("GENELMALZEME");

                entity.Property(e => e.Genelsizeid).HasColumnName("GENELSIZEID");

                entity.Property(e => e.Gerceklesenfire).HasColumnName("GERCEKLESENFIRE");

                entity.Property(e => e.Giris).HasColumnName("GIRIS");

                entity.Property(e => e.Grupmu)
                    .HasColumnName("GRUPMU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gtip)
                    .HasMaxLength(17)
                    .HasColumnName("GTIP");

                entity.Property(e => e.Hizlisatis)
                    .HasColumnName("HIZLISATIS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Icambalaj)
                    .HasColumnName("ICAMBALAJ")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isilislem)
                    .HasColumnName("ISILISLEM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isilislemaciklama)
                    .HasMaxLength(25)
                    .HasColumnName("ISILISLEMACIKLAMA");

                entity.Property(e => e.Isilislemdurum)
                    .HasMaxLength(200)
                    .HasColumnName("ISILISLEMDURUM");

                entity.Property(e => e.Islemturu)
                    .HasColumnName("ISLEMTURU")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Kalibiyapanfirma)
                    .HasMaxLength(200)
                    .HasColumnName("KALIBIYAPANFIRMA");

                entity.Property(e => e.Kalip)
                    .HasColumnName("KALIP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Kalipgozad).HasColumnName("KALIPGOZAD");

                entity.Property(e => e.Kalipyeri)
                    .HasMaxLength(50)
                    .HasColumnName("KALIPYERI");

                entity.Property(e => e.Karaliste)
                    .HasColumnName("KARALISTE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Karalistesebep)
                    .HasMaxLength(120)
                    .HasColumnName("KARALISTESEBEP");

                entity.Property(e => e.Kayitdate)
                    .HasPrecision(0)
                    .HasColumnName("KAYITDATE");

                entity.Property(e => e.Kayittarihi)
                    .HasPrecision(0)
                    .HasColumnName("KAYITTARIHI");

                entity.Property(e => e.Kayituser).HasColumnName("KAYITUSER");

                entity.Property(e => e.Kaynakmlz)
                    .HasMaxLength(50)
                    .HasColumnName("KAYNAKMLZ");

                entity.Property(e => e.KoliTipi)
                    .HasColumnName("KOLI_TIPI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Kritikolculer)
                    .HasMaxLength(500)
                    .HasColumnName("KRITIKOLCULER");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(250)
                    .HasColumnName("LOTNO");

                entity.Property(e => e.Maddehali)
                    .HasColumnName("MADDEHALI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Maliyethesaplanan).HasColumnName("MALIYETHESAPLANAN");

                entity.Property(e => e.Maliyeturetim).HasColumnName("MALIYETURETIM");

                entity.Property(e => e.Malzeme).HasColumnName("MALZEME");

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Modelid).HasColumnName("MODELID");

                entity.Property(e => e.Musterinumune)
                    .HasColumnName("MUSTERINUMUNE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Netagirlikkg)
                    .HasColumnName("NETAGIRLIKKG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Numuneonaydate)
                    .HasColumnType("datetime")
                    .HasColumnName("NUMUNEONAYDATE");

                entity.Property(e => e.Oran)
                    .HasColumnName("ORAN")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Oturma)
                    .HasMaxLength(10)
                    .HasColumnName("OTURMA");

                entity.Property(e => e.Parcaag).HasColumnName("PARCAAG");

                entity.Property(e => e.Parcadokumad)
                    .HasColumnName("PARCADOKUMAD")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Parcadokumag)
                    .HasColumnName("PARCADOKUMAG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Parcakayittar)
                    .HasColumnType("date")
                    .HasColumnName("PARCAKAYITTAR");

                entity.Property(e => e.Parcasektor)
                    .HasMaxLength(500)
                    .HasColumnName("PARCASEKTOR");

                entity.Property(e => e.Pasif)
                    .HasColumnName("PASIF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pasivasyon)
                    .HasColumnName("PASIVASYON")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pinbaccount)
                    .HasColumnName("PINBACCOUNT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PktBol)
                    .HasColumnName("PKT_BOL")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Qualityid).HasColumnName("QUALITYID");

                entity.Property(e => e.Recetesiz)
                    .HasColumnName("RECETESIZ")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Salkimdokumag)
                    .HasColumnName("SALKIMDOKUMAG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Salkimmumag)
                    .HasColumnName("SALKIMMUMAG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Salkimparcaad)
                    .HasColumnName("SALKIMPARCAAD")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sarfkodu)
                    .HasColumnName("SARFKODU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Scaleid).HasColumnName("SCALEID");

                entity.Property(e => e.Scariid)
                    .HasColumnName("SCARIID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Seramikfire).HasColumnName("SERAMIKFIRE");

                entity.Property(e => e.SertifikaId)
                    .HasColumnName("SERTIFIKA_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sertlik)
                    .HasMaxLength(200)
                    .HasColumnName("SERTLIK");

                entity.Property(e => e.Sfirmaid)
                    .HasColumnName("SFIRMAID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sfirmaidtemp)
                    .HasColumnName("SFIRMAIDTEMP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sifirlama)
                    .HasColumnName("SIFIRLAMA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sifirlamaaciklama)
                    .HasMaxLength(25)
                    .HasColumnName("SIFIRLAMAACIKLAMA");

                entity.Property(e => e.SiparisAdedi)
                    .HasMaxLength(20)
                    .HasColumnName("SIPARIS_ADEDI");

                entity.Property(e => e.Sonfireorani).HasColumnName("SONFIREORANI");

                entity.Property(e => e.Sonisemri)
                    .HasColumnName("SONISEMRI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stagirlik)
                    .HasMaxLength(20)
                    .HasColumnName("STAGIRLIK");

                entity.Property(e => e.Staksesuar)
                    .HasMaxLength(80)
                    .HasColumnName("STAKSESUAR");

                entity.Property(e => e.Stalisfiyat)
                    .HasColumnName("STALISFIYAT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stalisfiyattemp)
                    .HasColumnName("STALISFIYATTEMP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stbandrol)
                    .HasColumnName("STBANDROL")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stbeygir)
                    .HasMaxLength(50)
                    .HasColumnName("STBEYGIR");

                entity.Property(e => e.Stbirim)
                    .HasMaxLength(15)
                    .HasColumnName("STBIRIM")
                    .HasDefaultValueSql("(N'Ad')");

                entity.Property(e => e.Stbirim2)
                    .HasMaxLength(15)
                    .HasColumnName("STBIRIM2")
                    .HasDefaultValueSql("(N'Pk')");

                entity.Property(e => e.Stbirim2katsayi)
                    .HasColumnName("STBIRIM2KATSAYI")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stbirim3)
                    .HasMaxLength(15)
                    .HasColumnName("STBIRIM3");

                entity.Property(e => e.Stbirim3katsayi)
                    .HasColumnName("STBIRIM3KATSAYI")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stcinsi)
                    .HasMaxLength(50)
                    .HasColumnName("STCINSI");

                entity.Property(e => e.Stdoviz1)
                    .HasColumnName("STDOVIZ1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stdoviz2)
                    .HasColumnName("STDOVIZ2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stdoviz3)
                    .HasColumnName("STDOVIZ3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stikinciel)
                    .HasColumnName("STIKINCIEL")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stirtibat)
                    .HasMaxLength(80)
                    .HasColumnName("STIRTIBAT");

                entity.Property(e => e.Stiskonto)
                    .HasColumnName("STISKONTO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stistihap)
                    .HasMaxLength(20)
                    .HasColumnName("STISTIHAP");

                entity.Property(e => e.Stkatsayi2)
                    .HasColumnName("STKATSAYI2")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stkdv)
                    .HasColumnName("STKDV")
                    .HasDefaultValueSql("((18))");

                entity.Property(e => e.Stkdv2)
                    .HasColumnName("STKDV2")
                    .HasDefaultValueSql("((18))");

                entity.Property(e => e.Stkritik)
                    .HasColumnName("STKRITIK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stmarka)
                    .HasMaxLength(50)
                    .HasColumnName("STMARKA");

                entity.Property(e => e.Stmodel)
                    .HasMaxLength(50)
                    .HasColumnName("STMODEL");

                entity.Property(e => e.Stmotorhacim).HasColumnName("STMOTORHACIM");

                entity.Property(e => e.Stmotorno)
                    .HasMaxLength(80)
                    .HasColumnName("STMOTORNO");

                entity.Property(e => e.Stmuhkod)
                    .HasMaxLength(10)
                    .HasColumnName("STMUHKOD");

                entity.Property(e => e.Stnot)
                    .HasMaxLength(80)
                    .HasColumnName("STNOT");

                entity.Property(e => e.Stokadet)
                    .HasColumnName("STOKADET")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stokadi)
                    .HasMaxLength(250)
                    .HasColumnName("STOKADI");

                entity.Property(e => e.StokadiEn)
                    .HasMaxLength(250)
                    .HasColumnName("STOKADI_EN");

                entity.Property(e => e.StokadiFatura)
                    .HasMaxLength(250)
                    .HasColumnName("STOKADI_FATURA");

                entity.Property(e => e.StokadiFr)
                    .HasMaxLength(250)
                    .HasColumnName("STOKADI_FR");

                entity.Property(e => e.StokadiPrknd)
                    .HasMaxLength(200)
                    .HasColumnName("STOKADI_PRKND");

                entity.Property(e => e.Stokgrp1)
                    .HasMaxLength(30)
                    .HasColumnName("STOKGRP1");

                entity.Property(e => e.Stokgrp2)
                    .HasMaxLength(30)
                    .HasColumnName("STOKGRP2");

                entity.Property(e => e.Stokgrp3)
                    .HasMaxLength(25)
                    .HasColumnName("STOKGRP3");

                entity.Property(e => e.Stokgrp4)
                    .HasMaxLength(30)
                    .HasColumnName("STOKGRP4");

                entity.Property(e => e.Stokgrp5)
                    .HasMaxLength(30)
                    .HasColumnName("STOKGRP5");

                entity.Property(e => e.Stokgrp6)
                    .HasMaxLength(30)
                    .HasColumnName("STOKGRP6");

                entity.Property(e => e.Stokkod)
                    .HasMaxLength(80)
                    .HasColumnName("STOKKOD")
                    .HasDefaultValueSql("(N'0')");

                entity.Property(e => e.Stokturkod)
                    .HasColumnName("STOKTURKOD")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Stokturu)
                    .HasMaxLength(9)
                    .HasColumnName("STOKTURU")
                    .HasDefaultValueSql("(N'MAMUL')");

                entity.Property(e => e.Stoto)
                    .HasColumnName("STOTO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stotv)
                    .HasColumnName("STOTV")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stparabirim)
                    .HasMaxLength(10)
                    .HasColumnName("STPARABIRIM");

                entity.Property(e => e.Strafno)
                    .HasMaxLength(5)
                    .HasColumnName("STRAFNO");

                entity.Property(e => e.Strenk)
                    .HasMaxLength(50)
                    .HasColumnName("STRENK");

                entity.Property(e => e.Stsasino)
                    .HasMaxLength(80)
                    .HasColumnName("STSASINO");

                entity.Property(e => e.Stsatisfiyat1)
                    .HasColumnName("STSATISFIYAT1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat10)
                    .HasColumnName("STSATISFIYAT10")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat2)
                    .HasColumnName("STSATISFIYAT2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat3)
                    .HasColumnName("STSATISFIYAT3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat4)
                    .HasColumnName("STSATISFIYAT4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat4Yedek)
                    .HasColumnName("STSATISFIYAT4_YEDEK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat5)
                    .HasColumnName("STSATISFIYAT5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat6)
                    .HasColumnName("STSATISFIYAT6")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat6Yedek)
                    .HasColumnName("STSATISFIYAT6_YEDEK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat7)
                    .HasColumnName("STSATISFIYAT7")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat8)
                    .HasColumnName("STSATISFIYAT8")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsatisfiyat9)
                    .HasColumnName("STSATISFIYAT9")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stsilindir)
                    .HasMaxLength(15)
                    .HasColumnName("STSILINDIR");

                entity.Property(e => e.Stsilindir3)
                    .HasMaxLength(15)
                    .HasColumnName("STSILINDIR3");

                entity.Property(e => e.Stsirano)
                    .HasMaxLength(5)
                    .HasColumnName("STSIRANO");

                entity.Property(e => e.Stx).HasColumnName("STX");

                entity.Property(e => e.Sty).HasColumnName("STY");

                entity.Property(e => e.Styili).HasColumnName("STYILI");

                entity.Property(e => e.Stz).HasColumnName("STZ");

                entity.Property(e => e.Taahhutname)
                    .HasMaxLength(200)
                    .HasColumnName("TAAHHUTNAME");

                entity.Property(e => e.Tahminiolcu1)
                    .HasMaxLength(50)
                    .HasColumnName("TAHMINIOLCU1");

                entity.Property(e => e.Tahminiolcu2)
                    .HasMaxLength(50)
                    .HasColumnName("TAHMINIOLCU2");

                entity.Property(e => e.Tahminiolcu3)
                    .HasMaxLength(50)
                    .HasColumnName("TAHMINIOLCU3");

                entity.Property(e => e.Tahminiolcu4)
                    .HasMaxLength(50)
                    .HasColumnName("TAHMINIOLCU4");

                entity.Property(e => e.Teklif)
                    .HasColumnName("TEKLIF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Teknikresim)
                    .HasColumnName("TEKNIKRESIM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Teknikresimno)
                    .HasMaxLength(200)
                    .HasColumnName("TEKNIKRESIMNO")
                    .HasDefaultValueSql("(N'0')");

                entity.Property(e => e.Teslimaciklama)
                    .HasMaxLength(250)
                    .HasColumnName("TESLIMACIKLAMA");

                entity.Property(e => e.Toplamuretimad).HasColumnName("TOPLAMURETIMAD");

                entity.Property(e => e.Toplamuretimsayisi).HasColumnName("TOPLAMURETIMSAYISI");

                entity.Property(e => e.UnTipi)
                    .HasMaxLength(30)
                    .HasColumnName("UN_TIPI");

                entity.Property(e => e.Uretimfire)
                    .HasColumnName("URETIMFIRE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Uststokid).HasColumnName("USTSTOKID");

                entity.Property(e => e.Webdegoster)
                    .HasColumnName("WEBDEGOSTER")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yapiid).HasColumnName("YAPIID");

                entity.Property(e => e.Yeni)
                    .HasColumnName("YENI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yollukad)
                    .HasMaxLength(50)
                    .HasColumnName("YOLLUKAD");

                entity.Property(e => e.Yollukdurumu).HasColumnName("YOLLUKDURUMU");

                entity.Property(e => e.Yuzeykumlama).HasColumnName("YUZEYKUMLAMA");

                entity.Property(e => e.Zimpara)
                    .HasColumnName("ZIMPARA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Zimparaaciklama)
                    .HasMaxLength(25)
                    .HasColumnName("ZIMPARAACIKLAMA");
            });

            modelBuilder.Entity<Stimage>(entity =>
            {
                entity.HasKey(e => e.Stimageid)
                    .IsClustered(false);

                entity.ToTable("stimage");

                entity.HasIndex(e => e.Stimageid, "stimage$STIMAGEID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Stimageid).HasColumnName("STIMAGEID");

                entity.Property(e => e.Imageurl)
                    .HasMaxLength(250)
                    .HasColumnName("IMAGEURL");

                entity.Property(e => e.Stid).HasColumnName("STID");

                entity.Property(e => e.Stimage1).HasColumnName("STIMAGE");

                entity.Property(e => e.Tipi)
                    .HasMaxLength(1)
                    .HasColumnName("TIPI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
