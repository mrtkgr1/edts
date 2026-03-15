# EDTS - Stok Takip ve Yönetim Sistemi 📦

EDTS, yerel ağ (LAN) üzerinde İstemci-Sunucu (Client-Server) mimarisiyle çalışan, çok kullanıcılı ve yüksek performanslı bir masaüstü otomasyon yazılımıdır. İşletmelerin stok ve veri yönetimini merkezi bir sunucu üzerinden, pürüzsüz ve güvenli bir şekilde yapmasını sağlar.

## 🚀 Öne Çıkan Özellikler

* **Çok Kullanıcılı Mimari:** Ağ üzerindeki birden fazla bilgisayarın (İstemci) aynı anda tek bir merkeze (Sunucu) bağlanarak eşzamanlı çalışabilmesi.
* **Merkezi Veritabanı:** SQL Server altyapısı ile verilerin tek bir güvenli noktada tutulması ve anlık senkronizasyon.
* **Akıllı Kurulum (MSI):** Özel hazırlanan kurulum sihirbazı sayesinde tek tıkla kurulum. İstemci bilgisayarda eksik olan `.NET 8 Desktop Runtime` paketlerini otomatik tespit edip kurma yeteneği.
* **Yüksek Performans:** Modern .NET 8 mimarisi ve AOT (Ahead-Of-Time) derleme prensipleriyle optimize edilmiş hızlı açılış süreleri.

## 🛠️ Kullanılan Teknolojiler

* **Geliştirme Dili:** C# 
* **Çerçeve (Framework):** .NET Desktop Runtime 8.0 (x64)
* **Veritabanı:** Microsoft SQL Server (Express)
* **Paketleme/Dağıtım:** Visual Studio Installer Projects (.msi / setup.exe)

---

## ⚙️ Kurulum Talimatları

Proje, Ana Bilgisayar (Sunucu) ve Kullanıcı Bilgisayarları (İstemci) olmak üzere iki aşamalı bir yapıya sahiptir.

### 1. Sunucu (Server) Kurulumu
Veritabanının barındırılacağı ana bilgisayarda yapılması gerekenler:
1. SQL Server ve SQL Server Management Studio (SSMS) kurulumunu tamamlayın.
2. SSMS üzerinden `StokYonetimDB` (veya ilgili veritabanını) oluşturun ve tabloları içe aktarın.
3. SQL Server Configuration Manager'ı açın ve **TCP/IP** protokolünü etkinleştirin.
4. `IPAll` sekmesinde Dinamik Portları temizleyip, **TCP Portunu 1433** olarak sabitleyin.
5. SQL Servisini yeniden başlatın.
6. Windows Güvenlik Duvarı'nda (Firewall) `1433` portu için dışarıdan gelen bağlantılara (Inbound Rule) izin verin.

### 2. İstemci (Client) Kurulumu
Kullanıcıların bilgisayarlarına programı kurmak için:
1. Paylaşılan `setup.exe` veya `EDTS.msi` dosyasına çift tıklayın.
2. (Eğer sistemde yoksa) Kurulum sihirbazı `.NET 8 Desktop Runtime` paketini otomatik olarak indirecektir, onaylayın.
3. Kurulum tamamlandığında masaüstündeki **EDTS** kısayoluna tıklayarak programı başlatın.
4. Program açıldığında "Bağlantı Ayarları" ekranına Sunucu IP adresini (Örn: `192.168.1.108`) ve SQL Ad bilgilerini girerek sisteme bağlanın.

## 🔒 Güvenlik Notları
* Sistem, varsayılan `sa` yetkilisi yerine sadece EDTS uygulamasına özel yetkilendirilmiş spesifik bir SQL kullanıcısı ile çalışacak şekilde yapılandırılmıştır.
