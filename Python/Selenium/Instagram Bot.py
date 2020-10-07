from time import sleep ## Saniye bazlı geciktirme işlemi yapabilmemiz için gereken kütüphane
from selenium.common.exceptions import NoSuchElementException ## Selenium hata ayıklamaları için gerekli kütüphane
from selenium.webdriver.common.keys import Keys ## Selenium ile birlikte klavyeyi simüle etmemize yarayan kütüphane
from selenium import webdriver ## Selenium web driver kütüphanesi
tarayiciDriverKonum = "C:\\Users\\ahmet\\Desktop\\Python\\Selenium\\geckodriver.exe" ## Web driver konumu

"""
Özellikler

Takip Et
Takipten Çık
Takip Edenler
Takip Ettikleri
Takip Etmeyenler
Profil Analiz

"""


class Instagram:
    def __init__(self, tarayiciKonum, url="https://www.urhoba.net", kullaniciAdi="kullanıcı adı", sifre="şifre"):
        self.tarayici = webdriver.Firefox(executable_path=tarayiciDriverKonum)
        self.url = url
        self.girisurl = "https://www.instagram.com/accounts/login/"
        self.kullaniciAdi = kullaniciAdi
        self.sifre = sifre
        self.girisYapilmismi = False
        self.tumTakipciler = []
        self.tumTakipEdilenler = []

    def TarayiciAc(self):
        try:            
            self.tarayici.get(self.url)
            print("Tarayıcı açıldı.")
            self.tarayici.implicitly_wait(10)
        except:
            print("Tarayıcı açılırken bir sorun ile karşılaşıldı!")

    def TarayiciKapat(self):
        self.tarayici.close()

    def GirisYap(self, url):
        try:
            self.tarayici.get(url)
            self.tarayici.implicitly_wait(10)
            kullaniciAdiInput = self.tarayici.find_element_by_css_selector(
                "input[name='username']")
            sifreInput = self.tarayici.find_element_by_css_selector(
                "input[name='password']")
            girisButon = self.tarayici.find_element_by_xpath(
                "//button[@type='submit']")
            kullaniciAdiInput.send_keys(self.kullaniciAdi)
            sifreInput.send_keys(self.sifre)
            girisButon.click()
            print("Hesaba başarılı bir şekilde giriş yapıldı.")
            self.girisYapilmismi = True
            sleep(10)

        except:
            print("Hesaba giriş yapılırken bir sorun ile karşılaşıldı!")

    def TakipEt(self, kullaniciAdi):
        if self.girisYapilmismi == True:
            try:
                self.tarayici.get(self.url + kullaniciAdi)
                self.tarayici.implicitly_wait(10)
                takipEtButton = self.tarayici.find_element_by_css_selector(
                    'button')
                if takipEtButton.text == "Takip Et":
                    takipEtButton.click()
                    print(kullaniciAdi + " Takip edildi")
                else:
                    print(kullaniciAdi + " Zaten takip ediliyor..")

            except:
                print(kullaniciAdi + " Takip edilirken bir hata ile karşılaşıldı!")
        else:
            print("Lütfen birini takip etmek için önce bir hesap ile giriş yapın!")

    def TakiptenCik(self, kullaniciAdi):
        if self.girisYapilmismi == True:
            try:
                self.tarayici.get(self.url + kullaniciAdi)
                self.tarayici.implicitly_wait(10)
                takiptenCikButton1 = self.tarayici.find_element_by_xpath(
                    '//*[@id="react-root"]/section/main/div/header/section/div[1]/div[1]/div/div[2]/div/span/span[1]/button/div/span')
                takiptenCikButton1.click()
                self.tarayici.implicitly_wait(10)
                takiptenCikButton2 = self.tarayici.find_element_by_xpath(
                    '/html/body/div[4]/div/div/div/div[3]/button[1]')
                if takiptenCikButton2.text == "Takibi Bırak":
                    takiptenCikButton2.click()
                    self.tarayici.implicitly_wait(10)
                    print(kullaniciAdi + " Takipten çıkıldı.")
            except:
                print(kullaniciAdi + "Takipten çıkılırken bir sorun ile karşılaşıldı!")
        else:
            print("Lütfen birini takipten çıkmak için önce bir hesap ile giriş yapın!")

    def ProfilAnaliz(self, kullaniciAdi):
        try:
            self.tarayici.get(self.url + kullaniciAdi)
            self.tarayici.implicitly_wait(10)
            gonderiSayisi = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/ul/li[1]/a/span')
            takipciSayisi = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/ul/li[2]/a/span')
            takipEdilenSayisi = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/ul/li[3]/a/span')
            kullaniciIsim = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/div[2]/h1')
            kullaniciBio = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/div[2]/span')
            kullaniciURL = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/header/section/div[2]/a')
            print("Hesap : " + kullaniciAdi + "\nİsim : " + kullaniciIsim.text + "\nBiyografi : " + kullaniciBio.text + "\nURL : " + kullaniciURL.text +
                  "\nGönderi sayısı : " + gonderiSayisi.text + "\nTakipci sayısı : " + takipciSayisi.text + "\nTakip edilen sayısı : " + takipEdilenSayisi.text)
        except:
            print(kullaniciAdi +
                  " Profili analiz edilirken bir sorun ile karşılaşıldı!")

    def HesapGizlimi(self, kullaniciAdi):
        try:
            self.tarayici.get(self.url + kullaniciAdi)
            self.tarayici.implicitly_wait(10)
            hesapGizlimi = self.tarayici.find_element_by_xpath(
                '/html/body/div[1]/section/main/div/div/article/div/div/h2')
            if hesapGizlimi.text == "Bu Hesap Gizli":
                return True
            else:
                return False
        except NoSuchElementException:
            return False
        else:
            print("Hesap gizlimi kontrol edilirken bir sorun ile karşılaşıldı!")

    def TakipEdenleriGoster(self, kullaniciAdi, gosterGizle = False):
        if self.HesapGizlimi(kullaniciAdi):
            print("Hesap gizli olduğu için takip edenleri göremiyorum!")
        else:
                self.tarayici.get(self.url + kullaniciAdi)
                self.tarayici.implicitly_wait(10)
                takipEdenlerLink = self.tarayici.find_element_by_xpath(
                "//*[@id='react-root']/section/main/div/header/section/ul/li[2]/a").click()
                self.tarayici.implicitly_wait(10)
                pencere = self.tarayici.find_element_by_css_selector("div[role=dialog] ul")
                takipEdenSayac = len(pencere.find_elements_by_css_selector("li"))
                print("Şu anda "+ str(takipEdenSayac) +" takip edeniniz var.")

                self.action = webdriver.ActionChains(self.tarayici)
                pencere.click()
                
                while True:
                    self.action.key_down(Keys.END).key_up(Keys.SPACE).perform()
                    sleep(5)                    
                    yeniSayac = len(pencere.find_elements_by_css_selector("li"))

                    if takipEdenSayac != yeniSayac:
                        takipEdenSayac = yeniSayac
                        print("Toplam takipçi " + str(yeniSayac))
                        self.tarayici.implicitly_wait(15)
                    else: 
                        break                                      
                    
                takipciler = pencere.find_elements_by_css_selector("li")

                for hesap in takipciler:
                    link = hesap.find_element_by_css_selector("a").get_attribute("href")
                    self.tumTakipciler.append(link)
                    if gosterGizle:
                        print(link)

    def TakipEttikleriniGoster(self, kullaniciAdi, gosterGizle = False):
        if self.HesapGizlimi(kullaniciAdi):
            print("Hesap gizli olduğu için takip ettiklerini göremiyorum!")
        else:
            self.tarayici.get(self.url + kullaniciAdi)
            self.tarayici.implicitly_wait(10)
            takipEttikleriLink = self.tarayici.find_element_by_xpath(
            "//*[@id='react-root']/section/main/div/header/section/ul/li[3]/a").click()
            self.tarayici.implicitly_wait(10)
            pencere = self.tarayici.find_element_by_css_selector("div[role=dialog] ul")
            takipEttikleriSayac = len(pencere.find_elements_by_css_selector("li"))
            print("Şu anda "+ str(takipEttikleriSayac) +" kişiyi takip ediyorsunuz.")

            self.action = webdriver.ActionChains(self.tarayici)
            pencere.click()

            while True:
                self.action.key_down(Keys.END).key_up(Keys.SPACE).perform()
                sleep(5)                    
                yeniSayac = len(pencere.find_elements_by_css_selector("li"))

                if takipEttikleriSayac != yeniSayac:
                    takipEttikleriSayac = yeniSayac
                    print("Toplam takip ettiğin " + str(yeniSayac))
                    self.tarayici.implicitly_wait(15)
                else: 
                    break                                      
                    
            takipedilenler = pencere.find_elements_by_css_selector("li")

            for hesap in takipedilenler:
                link = hesap.find_element_by_css_selector("a").get_attribute("href")
                self.tumTakipEdilenler.append(link)
                if gosterGizle:
                    print(link)

    def TakipEtmeyenler(self):
        if len(self.tumTakipEdilenler) != 0 and len(self.tumTakipciler) != 0:
            print("Takip Etmeyenler")
            for takipEdilenler in self.tumTakipEdilenler:
                if takipEdilenler not in self.tumTakipciler:
                    print(takipEdilenler)   
        else:
            print("Lütfen ilk olarak takipcileri ve takip edilenleri gösterin!")


Ins = Instagram(tarayiciDriverKonum, "https://instagram.com/", "kullanıcı adı", "şifre")
Ins.TarayiciAc()
Ins.ProfilAnaliz("urhob")
Ins.GirisYap("https://www.instagram.com/accounts/login/")
Ins.TakipEdenleriGoster("urhoba",True)
Ins.TakipEttikleriniGoster("urhoba",True)
Ins.TakipEtmeyenler()
Ins.TakiptenCik("urhoba")
Ins.TakipEt("urhoba")



print(input())
