from . import views
from django.urls import path

urlpatterns = [
    path('', views.index, name='index'),
    path('new/', views.new_post, name='new_post'),
    path('/<int:pk>', views.post_detail, name='post_detail')
]