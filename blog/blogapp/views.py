from django.shortcuts import get_object_or_404, redirect, render
from .models import Post, Comment
from .forms import PostForm, CommentForm

# Create your views here.
def index(request):
    posts = Post.objects.all().order_by('-created_at')
    return render(request, 'blogapp/index.html', {'posts': posts})

def new_post(request):
    form = PostForm(request.POST or None)
    if request.method == 'POST' and form.is_valid():
        post = Post.objects.create(
            title = form.cleaned_data['title'],
            content = form.cleaned_data['content']
        )
        return redirect('post_detail', pk=post.pk)
    return render(request, 'blogapp/new_post.html', {'form': form})

def post_detail(request, pk):
    post = get_object_or_404(Post, pk=pk)
    comments = post.comments.all().order_by('created_at')
    form = CommentForm(request.POST or None)
    if request.method == 'POST' and form.is_valid():
        Comment.objects.create(
            post=post,
            author_name=form.cleaned_data['author_name'],
            text=form.cleaned_data['text']
        )
        return redirect('post_detail', pk=post.pk)
    return render(request, 'blogapp/post_detail.html', {
        'post': post,
        'comments': comments,
        'form': form
    })