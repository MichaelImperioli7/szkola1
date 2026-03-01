import re

from django.shortcuts import render

# Create your views here.
def index(request):
    return render(request, 'appmonday/index.html')

def form(request):
    return render(request, 'appmonday/form.html')

def show(request):
    context = {
        "name": "",
        "nazwisko": "",
        "email": "",
        "nr_telefonu": "",
        "wyksztalcenie": "",
        "errors": {}
    }

    phone_re = r"^\d{9}$"
    email_re = r"^[^@\s]+@[^@\s]+\.[^@\s]+$"

    if request.method == 'POST':
        context["name"] = request.POST.get("input_name", "").strip()
        context["nazwisko"] = request.POST.get("input_nazwisko", "").strip()
        context["email"] = request.POST.get("input_email", "").strip()
        numer = request.POST.get("input_nr_telefonu", "").strip()
        context["nr_telefonu"] = numer.replace("-", "")
        context["wyksztalcenie"] = request.POST.get("input_wyksztalcenie", "").strip()

        if not context["name"]:
            context["errors"]["name"] = "Imię jest wymagane."
        elif len(context["name"]) < 2:
            context["errors"]["name"] = "Imię jest za krótkie."

        if not context["nazwisko"]:
            context["errors"]["nazwisko"] = "Nazwisko jest wymagane."

        if not context["email"]:
            context["errors"]["email"] = "Email jest wymagany."
        elif not re.match(email_re, context["email"]):
            context["errors"]["email"] = "Nieprawidłowy format emaila."

        if not context["nr_telefonu"]:
            context["errors"]["nr_telefonu"] = "Numer telefonu jest wymagany."
        elif not re.match(phone_re, context["nr_telefonu"]):
            context["errors"]["nr_telefonu"] = "Podaj 9 cyfr numeru; my usuniemy znaki '-' automatycznie."

        if not context["wyksztalcenie"]:
            context["errors"]["wyksztalcenie"] = "Wybierz wykształcenie."

        if context["errors"]:
            return render(request, 'appmonday/form.html', context)
        else:
            return render(request, 'appmonday/show.html', context)

    return render(request, 'appmonday/form.html', context)