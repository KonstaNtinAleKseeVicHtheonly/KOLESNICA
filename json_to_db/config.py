"""Файл для создания локальных переменных, необходимых для подключения к POSTGRE"""
# host = '127.0.0.1'  # Поменять есил работа производится с сервера
# password = '12345'
# db_name = 'hahak'
# user_name = "postgres"
# port = 5432
path_to_json = r'C:\Users\ept13\Downloads\user_3'

# Словарь для работы с postgre

DATABASES = {

    'ENGINE': 'django.db.backends.postgresql',
    'DB_NAME': 'hahak',
    'USER_NAME': 'postgres',
    'PASSWORD': '12345',
    'HOST': '127.0.0.1',
    'PORT': '5432',
}
