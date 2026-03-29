from django import forms
from .models import Recipe

class RecipeForm(forms.ModelForm):
    class Meta:
        model = Recipe
        fields = ['name', 'description', 'prep_time', 'servings', 'photo']
        widgets = {
            'name': forms.TextInput(attrs={'placeholder': 'Nazwa przepisu'}),
            'description': forms.Textarea(attrs={'placeholder': 'Opis'}),
            'prep_time': forms.NumberInput(attrs={'placeholder': 'Minuty'}),
            'servings': forms.NumberInput(attrs={'placeholder': 'Porcje'}),
            'photo': forms.FileInput(),
        }