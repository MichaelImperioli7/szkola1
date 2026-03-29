from django.db import models

class Recipe(models.Model):
    name = models.CharField(max_length=200)
    description = models.TextField()
    prep_time = models.IntegerField(help_text='czas w minutach')
    servings = models.IntegerField(null=True, blank=True)
    photo = models.ImageField(upload_to='recipes/', blank=True, null=True)
    created_at = models.DateTimeField(auto_now_add=True)
    
    def __str__(self):
        return self.name