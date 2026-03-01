from django.urls import path
from . import views

urlpatterns = [
    path('', views.index, name="index"),
    path('people/', views.people, name="people"),
    path('auta/', views.auta, name="auta"),
    path('auta/<int:id>', views.auto_info, name="auto_info"),
    path('people/<int:id>', views.person_details, name="person_details"),
    path("people/<int:id>/edit/", views.person_edit, name="person_edit"),
    path("people/<int:id>/delete/", views.person_delete, name="person_delete"),
    path('form_auta/', views.form_auta, name="form_auta"),
    path('people/new/', views.new, name="new"),
]