public interface ISpawner
{
    void SpawnObject(int indexToExclude);

    void OnDispose(int index);
}