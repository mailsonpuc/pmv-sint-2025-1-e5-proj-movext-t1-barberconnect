import React, { useState } from 'react';
import {
  View,
  TextInput,
  StyleSheet,
  ImageBackground,
  TouchableOpacity,
  Text,
  Alert,
} from 'react-native';
import { useNavigation } from '@react-navigation/native';

export default function Login() {
  const navigation = useNavigation();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [tipoUsuario, setTipoUsuario] = useState('cliente');

  const handleLogin = async () => {
    try {
      const response = await fetch('https://SEU_BACKEND_URL/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password }),
      });

      const data = await response.json();

      if (data.success) {
        Alert.alert('Login bem-sucedido!');
        if (tipoUsuario === 'cliente') {
          navigation.navigate('Home');
        } else {
          navigation.navigate('HomeBarbeiro');
        }
      } else {
        Alert.alert('Erro', 'Usuário ou senha incorretos.');
      }
    } catch (error) {
      console.error('Erro ao fazer login:', error);
      Alert.alert('Erro', 'Não foi possível conectar ao servidor.');
    }
  };

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
      resizeMode="cover"
    >
      <View style={styles.container}>
        <View style={styles.userTypeContainer}>
          <TouchableOpacity
            style={[styles.userTypeButton, tipoUsuario === 'cliente' && styles.userTypeSelected]}
            onPress={() => setTipoUsuario('cliente')}
          >
            <Text style={styles.userTypeText}>CLIENTE</Text>
          </TouchableOpacity>

          <TouchableOpacity
            style={[styles.userTypeButton, tipoUsuario === 'barbeiro' && styles.userTypeSelected]}
            onPress={() => setTipoUsuario('barbeiro')}
          >
            <Text style={styles.userTypeText}>BARBEIRO</Text>
          </TouchableOpacity>
        </View>

        <TextInput
          placeholder="USUÁRIO"
          style={styles.input}
          placeholderTextColor="#fff"
          value={username}
          onChangeText={setUsername}
        />
        <TextInput
          placeholder="SENHA"
          style={styles.input}
          placeholderTextColor="#fff"
          secureTextEntry
          value={password}
          onChangeText={setPassword}
        />

        <TouchableOpacity style={styles.loginButton} onPress={handleLogin}>
          <Text style={styles.loginText}>LOGIN</Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.registerButton}
          onPress={() => navigation.navigate('Register')}
        >
          <Text style={styles.registerText}>CADASTRE-SE</Text>
        </TouchableOpacity>
      </View>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  container: {
    flex: 1,
    paddingHorizontal: 20,
    justifyContent: 'center',
  },
  userTypeContainer: {
    flexDirection: 'row',
    justifyContent: 'center',
    marginBottom: 20,
    gap: 10,
  },
  userTypeButton: {
    backgroundColor: '#444',
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 20,
  },
  userTypeSelected: {
    backgroundColor: '#888',
  },
  userTypeText: {
    color: '#fff',
    fontWeight: 'bold',
  },
  input: {
    backgroundColor: 'rgba(255, 255, 255, 0.2)',
    color: '#fff',
    height: 50,
    marginVertical: 10,
    borderRadius: 25,
    paddingHorizontal: 20,
  },
  loginButton: {
    backgroundColor: '#888',
    height: 50,
    borderRadius: 25,
    justifyContent: 'center',
    alignItems: 'center',
    marginVertical: 10,
  },
  loginText: {
    color: '#fff',
    fontWeight: 'bold',
  },
  registerButton: {
    backgroundColor: '#666',
    height: 40,
    borderRadius: 25,
    justifyContent: 'center',
    alignItems: 'center',
    marginVertical: 5,
  },
  registerText: {
    color: '#fff',
  },
});
