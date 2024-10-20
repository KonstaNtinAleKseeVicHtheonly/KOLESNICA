import json
from Project_POSTGRE.func_for_sql import insert_into_new_table


def json_to_dict(route: str):
    """в route указываем путь до файла, при вызове функции не забудь в аргументе добавить r в начало блеать json_to_dict(r'')"""
    with open(f"{route}.json", 'r', encoding='utf-8') as output:
        sum_up = json.load(output)
        # return output
        return sum_up


current_json = json_to_dict(r'D:\@Projects С#\AUTONOMUS\main\DataCommandTest\bin\Debug\net8.0-windows\AddUserRecord')
insert_into_new_table("user_info", current_json)