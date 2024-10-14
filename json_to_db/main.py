import psycopg2
from config import DATABASES, path_to_json
from receiver import json_to_dict
from func_for_sql import make_connection, create_table, insert_table, show_table, update_table, delete_table
# тестовые значения
a = {'Doljnost': 'ДИ', 'Otdel': 3,
     'Positive': 100, 'Negative': 30, 'Rating': "10"}
b = {'Doljnost': 'СИ', 'Otdel': '2',
     'Positive': 100, 'Negative': 130, 'Rating': 20}

if __name__ == '__main__':
    # insert_table(json_to_dict(r'C:\Users\ept13\Downloads\user_3'))
    create_table()
    insert_table(a)
    insert_table(b)
    show_table()
    # update_table(user_id=3, doljnost='яйца', otdel='2',
    #              positive=228, negative=0, rating=3)
    # delete_table()
