import psycopg2
from config import DATABASES, path_to_json
# from receiver import json_to_dict


# подключение к бд в POSTGRE
def make_connection():
    """Просто функция, делающая подключение к БД, что бы каждый раз не писать"""

    connection = psycopg2.connect(host=DATABASES['HOST'],
                                  user=DATABASES['USER_NAME'],
                                  password=DATABASES['PASSWORD'],
                                  database=DATABASES['DB_NAME'])
   # что бы все изменения записывались автоматически в БД иначе писать после каждой команды connection.commit()
    connection.autocommit = True
    return connection


def create_table():
    """Функция длс яоздания таблицы с статическими параметрами на языке sql"""
    try:
        initial = make_connection()

    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")
        # print('Скорее всего ошибка с входными данными - проверьте пароль, ip,имя пользователя и имя БД')
    else:
        with initial.cursor() as cursor:
            cursor.execute("""CREATE TABLE IF NOT EXISTS users_info_1(
                        User_id INTEGER NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
                        Doljnost VARCHAR(20) NOT NULL,
                        Otdel VARCHAR(20) NOT NULL,
                        Positive INTEGER DEFAULT 0,
                        Negative INTEGER DEFAULT 0,
                        Rating INTEGER DEFAULT 0);""")
            print('Таблица создана успешно')
        if initial:
            initial.close()  # через контекстный менеджер не катит в postgre, увы
            print('Соединение с БД закрыто')


# infa = {'Doljnost': 'dsas', 'Otdel': 'ssadasads',
#         'Positive': 0, 'Negative': 0, 'Rating': 0}
def show_table():
    """Покажет всю таблицу в консоли"""
    try:
        initial = make_connection()

    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")
    else:
        with initial.cursor() as cursor:
            cursor.execute("""SELECT * FROM users_info_1;""")
            print(cursor.fetchone())
        if initial:
            initial.close()  # через контекстный менеджер не катит в postgre, увы
            print('Соединение с БД закрыто')


def insert_table(value_insert: dict):
    """Аналогично команде INSERT в SQL - создание новой строки таблицы"""
    try:
        initial = make_connection()

    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")
    else:
        # turner = ','.join(list(value_insert.values()))
        turner = ', '.join([i if type(i) != int else str(i)
                           for i in value_insert.values()])
        hz = []
        for v in value_insert.values():
            hz.append(str(v))
        hz = [f"'{elem}'" if elem.isalpha() else elem for elem in hz]
        hz = ','.join(hz)

        with initial.cursor() as cursor:
            cursor.execute(
                f"INSERT INTO users_info_1(doljnost, otdel, positive, negative, rating) VALUES({hz})")
            print('Таблица дополнена успешно')
        if initial:
            initial.close()  # через контекстный менеджер не катит в postgre, увы
            print('Соединение с БД закрыто')


def update_table(**kwargs):
    """Функция для Обновления  уже созданных данных таблицы  на языке sql"""
    new_info = kwargs
    try:
        initial = make_connection()
    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")

    else:
        with initial.cursor() as cursor:
            cursor.execute(f"""
                           UPDATE users_info_1 SET doljnost='{new_info['doljnost']}', otdel='{new_info['otdel']}', positive={new_info['positive']},
                             negative={new_info['negative']}, rating={new_info['rating']} WHERE user_id={new_info['user_id']} """)
            print(
                f"Таблица обновлена  успешно, были добавлены данные: {list(kwargs.values())}")
        if initial:
            initial.close()  # через контекстный менеджер не катит в postgre, увы
            print('Соединение с БД закрыто')


def delete_table():
    try:
        initial = make_connection()

    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")
        # print('Скорее всего ошибка с входными данными - проверьте пароль, ip,имя пользователя и имя БД')
    else:
        with initial.cursor() as cursor:
            cursor.execute("""DROP TABLE users_info_1;""")
            print('Таблица удалена')
        if initial:
            initial.close()  # через контекстный менеджер не катит в postgre, увы
            print('Соединение с БД закрыто')
