def ForPalindrom(deger):
    yeniDeger = "" # Yeni kelimeyi tutmak için değişken oluşturduk
    for i in range(len(deger) -1, -1, -1): # Girilen değeri tersten yazmak için ters dönen bir for oluşturduk
        yeniDeger += deger[i] # Yeni değere sondaki harfi ekledik
    if yeniDeger == deger: # Yeni değer ile eski değer aynı ise 
        return True # True döndürdük
    else: # Aynı değil ise
        return False # False döndürdük

def WhilePalindrom(deger):
    yeniDeger = "" # Yeni kelimeyi tutmak için değişken oluşturduk
    counter = len(deger) -1 # While ı kontrol etmek için sayaç oluşturduk
    while counter >= 0: # Tersten okumak için While döngümüzü başlattık
        yeniDeger += deger[counter] # Yeni değere harfimizi ekledik
        counter -= 1 # Sayacımızı azalttık
    if yeniDeger == deger: # Yeni değer ile eski değer aynı ise 
        return True # True döndürdük
    else: # Aynı değil ise
        return False # False döndürdük

def PalindromKontrol(deger):
    return deger == deger[::-1] # Değerimizi değerimizin tersten yazılışı ile aynı mı kontrol ediyoruz, Bu Python da otomatik olarak aynı ise True değil ise False alacaktır.

# Kullanımları

forKontrol = ForPalindrom("ata")
whileKontrol = WhilePalindrom("ata")
palindromKontrol = PalindromKontrol("ata")

print(forKontrol, whileKontrol, palindromKontrol)
# Çıktısı "True True True"