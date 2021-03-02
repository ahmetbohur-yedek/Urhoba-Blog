from pytube import Playlist ## Playlist indirmek için olan kütüphane
from pytube import YouTube ## Tekli video indirmek için olan kütüphane

## Tekli video indirmek için yazdığımız fonksiyon
def TekVideoIndir(link):
    try: ## Hata varmı kontrol ediyoruz
        video = YouTube(link) ## Hata yok ise video değişkenini YouTube(bağlantıAdresi) fonksiyonu olarak atıyoruz
        print("%s Adlı video indirilmeye başlandı.." % video.title) ## Videonun adını ekrana yazdırıyoruz
        video.streams.get_highest_resolution().download('video') ## İndirmeyi başlatıyoruz Burada steams.get_highest_resolution kısmı en yüksek kaliteyi seçmemizi sağlar .download indirmeyi başlatır ve download('video') ise hangi klasöre indirileceğidir.
        print("%s Adlı video başarılı bir şekilde indirildi." % video.title) ## İndirme tamamlandı yazdırıyoruz
    except: ## Sorun var ise
        print("İşlem esnasında bir sorun ile karşılaşıldı!") ## Ekrana hata var yazdırıyoruz


def SadeceSesIndir(link):
    try: ## Hata varmı kontrol ediyoruz
        ses = YouTube(link) ## Hata yok ise video değişkenini YouTube(bağlantıAdresi) fonksiyonu olarak atıyoruz
        print("%s Adlı videonun ses dosyası indirilmeye başlandı.." % ses.title) ## Videonun adını ekrana yazdırıyoruz
        ses.streams.get_audio_only().download("ses") ## Ses dosyası indirilmeye başlıyor ve steams.get_audio_only() sadece sesi indirmesini söyler ve .download('ses') burada ses yazan yer ineceği klasörü belirtir.
        print("%s Adlı videonun ses dosyası indirildi." % ses.title) ## İndirildiğini söylüyoruz 
    except: ## Sorun var ise
        print("İşlem esnasında bir sorun ile karşılaşıldı!") ## Ekrana hata var yazdırıyoruz


def PlaylistVideoIndir(link):
    try: ## Hata varmı kontrol ediyoruz
        playList = Playlist(link) ## playList adında değişken oluşturduk ve linki PlayList fonksiyonuna atadık ve youtubeden verileri çektik
        indirilenVideoSayisi = 0 ## Kaç video indirildi veya eksik mi indi öğrenmek için bir değişken oluşturuyoruz
        print("Playlistte %s adet video bulunmaktadır." %
              len(playList.video_urls)) ## Playlistte kaç video var ekrana yazdırıyoruz
        for i in playList.videos: ## Playlistteki videoları for ile çekiyoruz
            i.streams.get_highest_resolution().download('video') ## Tek tek indirmeye başlıyoruz
            indirilenVideoSayisi += 1 ## Videolar indikçe sayacı arttırıyoruz
            print(i.title + "İsimli video görüntüsü başarı ile indirildi")
        print("Playlistde bulunan %s video başarı ile indirildi." %
              indirilenVideoSayisi) ## İndirildiğini söylüyoruz
    except: ## Sorun var ise
        print("İşlem esnasında bir sorun ile karşılaşıldı!") ## Ekrana hata var yazdırıyoruz


def PlaylistSesIndir(link):
    try: ## Hata varmı kontrol ediyoruz
        playList = Playlist(link) ## playList adında değişken oluşturduk ve linki PlayList fonksiyonuna atadık ve youtubeden verileri çektik
        indirilenVideoSayisi = 0 ## Kaç video indirildi veya eksik mi indi öğrenmek için bir değişken oluşturuyoruz
        print("Playlistte %s adet ses bulunmaktadır." %
              len(playList.video_urls)) ## Playlistte kaç video var ekrana yazdırıyoruz
        for i in playList.videos: ## Playlistteki videoları for ile çekiyoruz
            i.streams.get_audio_only().download('ses') ## Ses dosyasını indiriyoruz
            indirilenVideoSayisi += 1 ## Sayacı 1 arttırıyoruz
            print(i.title + "İsimli videonun sesi başarı ile indirildi")
        print("Playlistde bulunan %s videonun sesi başarı ile indirildi." %
              indirilenVideoSayisi) ## İndirildiğini söylüyoruz
    except: ## Sorun var ise
        print("İşlem esnasında bir sorun ile karşılaşıldı!") ## Ekrana hata var yazdırıyoruz

## Yapılacak işlemi belirlemek için bir fonksiyon oluşturuyoruz.
def SecimEkrani():
    islem = input(
        "Hangi işlemi yapmak istersiniz? \nİşlem ---- Komut \nTekli video indir ---- \"1\" \nPlaylist video indir ---- \"2\" \nSadece ses indir ---- \"3\" \nPlaylist sadece ses indir ---- \"4\"\nİşleminiz : ") ## Kullanıcıdan işlem seçmesini istiyoruz
    if islem == "1":
        link = input("Video veya Playlist bağlantı adresini girin :") ## Kullanıcıdan video / playlist url si istiyoruz
        TekVideoIndir(link) ## İşleme göre fonksiyonumuzu çağırıyoruz
    elif islem == "2":
        link = input("Video veya Playlist bağlantı adresini girin :") ## Kullanıcıdan video / playlist url si istiyoruz
        PlaylistVideoIndir(link) ## İşleme göre fonksiyonumuzu çağırıyoruz
    elif islem == "3":
        link = input("Video veya Playlist bağlantı adresini girin :") ## Kullanıcıdan video / playlist url si istiyoruz
        SadeceSesIndir(link) ## İşleme göre fonksiyonumuzu çağırıyoruz
    elif islem == "4":
        link = input("Video veya Playlist bağlantı adresini girin :") ## Kullanıcıdan video / playlist url si istiyoruz
        PlaylistSesIndir(link) ## İşleme göre fonksiyonumuzu çağırıyoruz


SecimEkrani() ## Kodların çalışabilmesi için fonksiyonumuzu çağırıyoruz
