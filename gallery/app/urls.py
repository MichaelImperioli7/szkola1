from django.urls import path
from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('jablka/', views.jablka, name='jablka'),
    path('download/<int:pk>/', views.download, name='download')
    # bierze liczbe z url i przekazuje do views jako primary key
]
