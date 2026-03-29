from django.shortcuts import render, get_object_or_404, redirect
from .models import Post, Comment
from .forms import PostForm, CommentForm

# Create your views here.
def index(request):
    posts = Post.objects.order_by('-created_at')
    return render(request, 'blog2/index.html', {
        'posts': posts
    })

def new(request):
    if request.method == 'POST':
        form = PostForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('index')
    else:
        form = PostForm()
    return render(request, 'blog2/new.html', {
        'form': form
    })


def details(request, pk):
    post = get_object_or_404(Post, pk=pk)
    comments = post.comments.all().order_by('-created_at')
    if request.method == 'POST':
        form = CommentForm(request.POST)
        if form.is_valid():
            comment = form.save(commit=False)
            comment.post = post
            comment.save()
            return redirect('details', pk=pk)
    else:
        form = CommentForm()
    return render(request, 'blog2/details.html', {
        'post': post,
        'form': form,
        'comments': comments
    })
