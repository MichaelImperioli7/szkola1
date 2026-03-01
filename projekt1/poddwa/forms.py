from datetime import date
import re
from django import forms
from .models import Auto, Person

class AutoForm(forms.ModelForm):
    class Meta:
        model = Auto
        fields = [
            'marka', 'model', 'rok'
        ]
        widgets = {
            'marka': forms.TextInput(attrs={'placeholder': 'Marka'}),
            'model': forms.TextInput(attrs={'placeholder': 'Model'}),
            'rok': forms.NumberInput(attrs={'placeholder': 'Rok'}),
        }

class PersonForm(forms.ModelForm):
    class Meta:
        model = Person
        fields = ['imie', 'data_urodzenia', 'email', 'wzrost']
        widgets = {
            'imie': forms.TextInput(attrs={'placeholder': 'Imię'}),
            'data_urodzenia': forms.DateInput(attrs={'placeholder': 'RRRR-MM-DD'}, format='%Y-%m-%d'),
            'email': forms.EmailInput(attrs={'placeholder': 'E-mail'}),
            'wzrost': forms.NumberInput(attrs={'placeholder': 'Wzrost'}),
        }
        error_messages = {
            'data_urodzenia': {'invalid': 'Format RRRR-MM-DD'},
            'email': {'invalid': 'Niepoprawny email'},
        }

    def clean_imie(self):
        imie = self.cleaned_data['imie'].strip()
        if len(imie) < 2:
            raise forms.ValidationError("Imię jest za krótkie")
        if not re.match(r"^[A-ZĄĆĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,}$", imie):
            raise forms.ValidationError("Pierwsza duża litera, reszta małe")
        return imie

    def clean_wzrost(self):
        wzrost = self.cleaned_data['wzrost']
        if wzrost <= 0:
            raise forms.ValidationError("Wzrost musi być dodatni")
        return wzrost

    def clean_data_urodzenia(self):
        d = self.cleaned_data['data_urodzenia']
        if d > date.today():
            raise forms.ValidationError("Data urodzenia nie może być z przyszłości")
        return d