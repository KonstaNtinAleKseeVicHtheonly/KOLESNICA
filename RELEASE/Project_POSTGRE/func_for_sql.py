import psycopg2
from Project_POSTGRE.file_config import DATABASES

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

def insert_into_new_table(table_name: str, outer_dict: dict):
    """Добавляет в таблицу с паролем и логинм новые значенмя"""
    try:
        initial = make_connection()

    except BaseException as mistake:
        print(f"произошла ошибка {mistake}")
    else:
        hz = []
        for v in outer_dict.values():
            if v or v == 0:
                hz.append(str(v))
            else:
                if v != 0:
                    hz.append('empty')
        hz = [f"'{elem}'" if elem.isalpha() else elem for elem in hz[:2]]
        hz = ','.join(hz)
        with initial.cursor() as cursor:
            cursor.execute(f"""INSERT INTO {table_name} VALUES({hz})""")
            initial.close()