import re

from django.shortcuts import get_object_or_404, redirect, render
from .models import Person, Auto
from . import forms

def index(request):
    return render(request, 'poddwa/index.html')

def people(request):
    all_people = Person.objects.all()
    return render(request, 'poddwa/people.html', {
        'all_people': all_people
    })

def person_details(request, id):
    p_details = get_object_or_404(Person, pk=id)
    return render(request, 'poddwa/details.html', {
        'p_details': p_details
    })

def auta(request):
    auta = Auto.objects.all()
    return render(request, "poddwa/auta.html", {
        'auta': auta
    })

def auto_info(request, id):
    a_info = get_object_or_404(Auto, pk=id)
    return render(request, 'poddwa/info.html', {
        'auto_info': a_info
    })

def form_auta(request):
    if request.method == "POST":
        form = forms.AutoForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('auta')
    else:
        form = forms.AutoForm()
    return render(request, 'poddwa/form_auta.html', {
            "form": form
    })

def new(request):
    error_message = ''
    if request.POST:
        form = forms.PersonForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('people')
        else:
            error_message = "błędny formularz"  
    else:
        form = forms.PersonForm()
    return render(request, 'poddwa/new.html', {
        'form': form,
        'error_message': error_message
    })

def person_edit(request, id):
    person = get_object_or_404(Person, pk=id)
    if request.method == "POST":
        form = forms.PersonForm(request.POST, instance=person)
        if form.is_valid():
            form.save()
            return redirect("people")
    else:
        form = forms.PersonForm(instance=person)
    return render(request, "poddwa/person_edit.html", {"form": form, "person": person})


def person_delete(request, id):
    person = get_object_or_404(Person, pk=id)
    
    if request.method == "POST":
        person.delete()
        return redirect("people")
    
    return render(request, "poddwa/person_delete.html", {"person": person})