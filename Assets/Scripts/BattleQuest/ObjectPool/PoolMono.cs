using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        // Ссылка на префаб объекта
        public T prefab { get; }

        // Флаг для расширяемости пула
        public bool autoExpand { get; set; }

        // Ссылка на контейнер, в который будут складываться все объекты
        public Transform container { get; }

        // Лист, в котором хранятся все объекты
        private List<T> pool;

        // Конструктор без контейнера
        public PoolMono(T prefab, int count)
        {
            this.prefab = prefab;
            this.container = null;

            this.CreatePool(count);
        }

        // Конструктор с контейнером
        public PoolMono(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;

            this.CreatePool(count);
        }

        // Метод, создающий пул
        private void CreatePool(int count)
        {
            this.pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                this.CreateObject();
            }
        }

        // Метод, создающий объекты
        // Флажок isActiveByDefault делает объект по умолчанию неактивным
        private T CreateObject(bool isActiveByDefault = false)
        {
            // Создаём объект
            var createdObject = UnityEngine.Object.Instantiate(this.prefab, this.container);
            // Скрываем или делаем активным
            createdObject.gameObject.SetActive(isActiveByDefault);
            // Добавляем в список
            this.pool.Add(createdObject);
            return createdObject;
        }

        // Проверка наличия свободного элемента в пуле
        public bool HasFreeElement(out T element)
        {
            foreach (var mono in pool)
            {
                // Если объект отключен
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        // Получаем свободный элемент из пула
        public T GetFreeElement()
        {
            // Если есть свободный элемент, возвращаем его
            if (this.HasFreeElement(out var element))
                return element;

            // Если пул расширяемый, создаем новый объект
            if (this.autoExpand)
                return this.CreateObject(true);

            // Если свободных объектов нет и пул не расширяемый, выбрасываем ошибку
            throw new Exception($"There is no free elements in pool of type {typeof(T)}");
        }

        public void SetObject(T element)
        {
            element.gameObject.SetActive(false); // Деактивируем объект, чтобы он стал доступным в пуле
        }
        
    }
}
