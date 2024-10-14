"""Файл для получения данных из json и преобразования их в словарь для передачи в таблицы postgresql"""

import json


def json_to_dict(route: str):
    """в route указываем путь до файла, при вызове функции не забудь в аргументе добавить r в начало блеать json_to_dict(r'')"""
    with open(f"{route}.json", 'r', encoding='utf-8') as output:
        sum_up = json.load(output)
        # return output
        return sum_up


if __name__ == '__main__':
    path = r'C:\Users\ept13\Downloads\user_3'
    a = json_to_dict(path)
    # print(' , '.join(list(a.values())))
    # hz = [i if type(i) != int else str(i) for i in a.values()]
    print(a)
