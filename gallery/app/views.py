from django.shortcuts import get_object_or_404, redirect, render
from .models import Photo
# Create your views here.

def index(request):
    return render(request, 'app/index.html')

def jablka(request):
    filtr = request.GET.get('filtr', '')
    # form w jablka.html ma get wiec przesyla dane do url, to bierze z url filtr lub zostawia puste gdy nic nia ma
    
    photos = Photo.objects.all().filter(title__icontains=filtr).order_by('-downloads')
    # The icontains lookup is used to get records that contains a specified value, case sensitive
    # -downloads odwraca order_by na descending

    return render(request, 'app/jablka.html', {
        'photos': photos,
        'filtr': filtr
    })

def download(request, pk):
    photo = get_object_or_404(Photo, pk=pk)
    photo.downloads+=1
    photo.save()
    return redirect('jablka')