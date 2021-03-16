using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public List<GameObject> characters;
    private GameObject currentCharacter;
    public List<GameObject> _tempCharacters = new List<GameObject>();
    public List<string> animations;
    public string currentAnimation;
    private List<string> _tempAnimations = new List<string>();
    private Animator animator;
    public Button ChangeAnimationButton;
    public Button ChangeCharacterButton;
    public bool allCharacters;
    public List<float> cameraZPositions;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        ChangeAnimationButton.onClick.AddListener(OnChangeAnimationButtonClick);
        ChangeCharacterButton.onClick.AddListener(CreateCharacter);

        CreateTempCharactersList();
        CreateTempAnimationsList();

        SelectAnimation();
        CreateCharacter();
    }

    void SetCameraPosition(float _value)
    {
        Vector3 _vector = Camera.main.transform.localPosition;
        Camera.main.transform.localPosition = new Vector3(_vector.x, _vector.y, _value);
    }

    void CreateCharacter()
    {
        if (allCharacters)
        {
            SetCameraPosition(cameraZPositions[1]);
            CreatePlaces();
            CreateAllCharacters();
            DestroyCurrentCharacter();
        }
        else
        {
            SetCameraPosition(cameraZPositions[0]);

            DestroyCharacters();
            DestroyCurrentCharacter();

            currentCharacter = Instantiate(Character());

            _tempCharacters.Remove(Character());
            if (_tempCharacters.Count <= 0)
            {
                CreateTempCharactersList();
                allCharacters = true;
            }

            animator = currentCharacter.GetComponent<Animator>();

            PlayAnimation(currentAnimation);
        }
    }

    void DestroyCharacters()
    {
        foreach (Transform _value in transform)
        {
            Destroy(_value.gameObject);
        }
    }

    void DestroyCurrentCharacter()
    {
        if (currentCharacter) Destroy(currentCharacter);
    }

    void CreateAllCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject _gameObject = Instantiate(characters[i], GetPosition(i), Quaternion.identity);
            _gameObject.transform.parent = transform;
            _gameObject.GetComponent<Animator>().Play(animations[Random.Range(0, animations.Count)]);

        }
        allCharacters = false;
    }

    Vector3 GetPosition(int _value)
    {
        return _places[_value];
    }

    void CreateTempCharactersList()
    {
        foreach (GameObject _value in characters)
        {
            _tempCharacters.Add(_value);
        }
    }
    void CreateTempAnimationsList()
    {
        foreach (string _value in animations)
        {
            _tempAnimations.Add(_value);
        }
    }

    GameObject Character()
    {
        return _tempCharacters[0];
    }

    string SelectAnimation()
    {
        currentAnimation = _tempAnimations[0];
        _tempAnimations.Remove(currentAnimation);
        if (_tempAnimations.Count <= 0) CreateTempAnimationsList();
        return currentAnimation;
    }

    void OnChangeAnimationButtonClick()
    {
        PlayAnimation(SelectAnimation());
        ResetCharacterTransform();
    }

    void PlayAnimation(string _value)
    {
        animator.Play(_value);
    }

    void ResetCharacterTransform()
    {
        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.localEulerAngles = Vector3.zero;
    }


    public List<Vector3> _places;
    public bool positiveDirectionX;
    public bool positiveDirectionZ;

    public int _unitInRow = 5;

    public Vector3 firstPlaceOffset = new Vector3(2f, 0f, 2f);
    public float _unitDistance = 2f;
    public float _value = 0.5f;

    public virtual Vector3 GetFirstPlacePosition()
    {
        return transform.position + firstPlaceOffset;
    }

    public virtual void CreatePlaces()
    {
        _places.Clear();
        float _direction;
        if (positiveDirectionX) _direction = _unitDistance;
        else _direction = -_unitDistance;

        float _directionZ;
        if (positiveDirectionZ) _directionZ = _unitDistance;
        else _directionZ = -_unitDistance;

        float _xPos = 0f, _zPos = 0f, _XRowOffset = _unitDistance * 0.5f, _Offset = _XRowOffset;
        Vector3 _position = GetFirstPlacePosition();

        for (int i = 0; i < characters.Count; i++)
        {
            if (i != 0 && i % _unitInRow == 0)
            {
                _zPos = _zPos + _directionZ;
                _xPos = _xPos - _direction;
                _direction = -_direction;

                _XRowOffset = -_XRowOffset;
                _Offset = _XRowOffset;
            }
            else
            {
                _Offset = 0f;
                _zPos = 0f;
                if (i == 0) _xPos = 0f;
                else _xPos = _direction;
            }
            _position = _position + new Vector3(_xPos + _Offset, 0f, _zPos);
            Vector3 _vector = new Vector3(_position.x + Random.Range(-_value, _value), _position.y, _position.z);
            _places.Add(_vector);
        }
    }
}
