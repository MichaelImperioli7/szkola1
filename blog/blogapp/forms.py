from django import forms

class PostForm(forms.Form):
    title = forms.CharField(max_length=120)
    content = forms.CharField(widget=forms.Textarea)

class CommentForm(forms.Form):
    author_name = forms.CharField(max_length=60)
    text = forms.CharField(widget=forms.Textarea)