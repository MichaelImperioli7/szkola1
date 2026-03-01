from django.db import models

class Person(models.Model):
    class Meta:
        verbose_name_plural = "people"
    imie = models.CharField(max_length=50, verbose_name="Imie")
    data_urodzenia = models.DateField(verbose_name="Data urodzenia")
    email = models.EmailField(verbose_name="Email")
    wzrost = models.IntegerField(verbose_name="Wzrost", default=170)

    def __str__(self):
        return self.imie
    
class Auto(models.Model):
    class Meta:
        verbose_name_plural = "auta"

    marka = models.CharField(max_length=30, verbose_name="Marka")
    model = models.CharField(max_length=30, verbose_name="Model")
    rok = models.IntegerField(verbose_name="Rok")