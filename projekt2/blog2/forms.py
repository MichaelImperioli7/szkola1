from django import forms
from .models import Post, Comment

class PostForm(forms.ModelForm):
    class Meta:
        model = Post
        fields = ['title', 'content']
        widgets = {
            'title': forms.TextInput(attrs={'placeholder': 'Tytul'}),
            'content': forms.Textarea(attrs={'placeholder': 'Tresc'})
        }

class CommentForm(forms.ModelForm):
    class Meta:
        model = Comment
        fields = ['author', 'text']
        widgets = {
            'author': forms.TextInput(attrs={'placeholder': 'Autor'}),
            'text': forms.Textarea(attrs={'placeholder': 'Zawartosc'})
        }