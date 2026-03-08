from django.db import models

# Create your models here.
class Photo(models.Model):
    title = models.CharField(max_length=50, verbose_name="Nazwa zdjęcia")
    image = models.ImageField(upload_to="images/", verbose_name="Adres zdjęcia")
    downloads = models.IntegerField(default=0, verbose_name="Liczba pobrań")

    """
    w settings.py:
        STATIC_URL = '/static/'
        MEDIA_URL = '/media/'
        MEDIA_ROOT = BASE_DIR / 'media'
    """